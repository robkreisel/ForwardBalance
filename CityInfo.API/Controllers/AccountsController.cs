using AutoMapper;
using ForwardBalance.API.Models;
using ForwardBalance.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API.Controllers
{
    [ApiController]
    [Route("api/banks/{bankId}/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IMailService _mailService;
        private readonly IForwardBalanceRepository _fowardBalanceRepository;
        private readonly IMapper _mapper;

        public AccountsController(ILogger<AccountsController> logger, IMailService mailService,
            IForwardBalanceRepository forwardBalanceRepository, IMapper mapper)
        {
            _logger = logger ?? 
                throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? 
                throw new ArgumentNullException(nameof(mailService));
            _fowardBalanceRepository = forwardBalanceRepository ??
                throw new ArgumentNullException(nameof(forwardBalanceRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetAccounts(int bankId)
        {
            try
            {
                // throw new Exception("Exception example.");
                if (!_fowardBalanceRepository.BankExists(bankId))
                {
                    _logger.LogInformation($"Bank with id {bankId} wasn't found when " +
                        $"accessing accounts.");

                    return NotFound();
                }

                var accountsForBank = _fowardBalanceRepository.GetAccountsForBank(bankId);

                return Ok(_mapper.Map<IEnumerable<AccountDto>>(accountsForBank));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting accounts for bank with id {bankId}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("{id}", Name = "GetAccount")]
        public IActionResult GetAccount(int bankId, int id)
        {
            if (!_fowardBalanceRepository.BankExists(bankId))
            {
                return NotFound();
            }

            var account = _fowardBalanceRepository.GetAccountForBank(bankId, id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AccountDto>(account));
        }

        [HttpPost]
        public IActionResult CreateAccount(int bankId, AccountForCreationDto account)
        {
            if (account.Description == account.Name)
            {
                ModelState.AddModelError(
                    "Description",
                    "The provided description should be different than the name.");
            }

            // This is only necessary because of the validation check above. It is not
            // necessary for simple annotations validation only.
            // For more complicated validation, checkout FluentValidation on github
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_fowardBalanceRepository.BankExists(bankId))
            {
                return NotFound();
            }

            var finalAccount = _mapper.Map<Entities.Account>(account);

            _fowardBalanceRepository.AddAccountForBank(bankId, finalAccount);

            _fowardBalanceRepository.Save();

            var createdAccountToReturn = _mapper
                .Map<Models.AccountDto>(finalAccount);
            
            return CreatedAtRoute(
                "GetAccount",
                new { bankId, id = createdAccountToReturn.Id },
                createdAccountToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int bankId, int id, AccountForUpdateDto account)
        {
            if (account.Description == account.Name)
            {
                ModelState.AddModelError(
                    "Description",
                    "The provided description should be different than the name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_fowardBalanceRepository.BankExists(bankId))
            {
                return NotFound();
            }

            var accountEntity = _fowardBalanceRepository.GetAccountForBank(bankId, id);
            if (accountEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(account, accountEntity);

            _fowardBalanceRepository.UpdateAccountForBank(bankId, accountEntity);

            _fowardBalanceRepository.Save();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdatePointofInterest(int bankId, int id, 
            JsonPatchDocument<AccountForUpdateDto> patchDoc)
        {
            if (!_fowardBalanceRepository.BankExists(bankId))
            {
                return NotFound();
            }

            var accountEntity = _fowardBalanceRepository
                .GetAccountForBank(bankId, id);
            if (accountEntity == null)
            {
                return NotFound();
            }

            var accountToPatch = _mapper.Map<AccountForUpdateDto>(accountEntity);

            patchDoc.ApplyTo(accountToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (accountToPatch.Description == accountToPatch.Name)
            {
                ModelState.AddModelError(
                     "Description",
                     "The provided description should be different than the name.");
            }

            if (!TryValidateModel(accountToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(accountToPatch, accountEntity);

            _fowardBalanceRepository.UpdateAccountForBank(bankId, accountEntity);

            _fowardBalanceRepository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int bankId, int id)
        {
            if (!_fowardBalanceRepository.BankExists(bankId))
            {
                return NotFound();
            }

            var accountEntity = _fowardBalanceRepository.GetAccountForBank(bankId, id);
            if (accountEntity == null)
            {
                return NotFound();
            }

            _fowardBalanceRepository.DeleteAccount(accountEntity);

            _fowardBalanceRepository.Save();

            _mailService.Send("Account deleted.",
                $"Account {accountEntity.Name} with id {accountEntity.Id} was deleted");

            return NoContent();
        }
    }
}
