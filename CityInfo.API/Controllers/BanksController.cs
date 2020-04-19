using AutoMapper;
using ForwardBalance.API.Models;
using ForwardBalance.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API.Controllers
{
    [ApiController]
    [Route("api/banks")]
    public class BanksController : ControllerBase
    {
        private readonly IForwardBalanceRepository _forwardBalanceRepository;
        private readonly IMapper _mapper;

        public BanksController(IForwardBalanceRepository forwardBalanceRepository,
            IMapper mapper)
        {
            _forwardBalanceRepository = forwardBalanceRepository ??
                throw new ArgumentNullException(nameof(forwardBalanceRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetBanks(bool includeHidden = false)
        {
            var bankEntities = _forwardBalanceRepository.GetBanks(includeHidden);

            return Ok(_mapper.Map<IEnumerable<BankWithoutAccountsDto>>(bankEntities));
        }

        [HttpGet("{id}")]
        public IActionResult GetBank(int id, bool includeAccounts = false)
        {
            var bank = _forwardBalanceRepository.GetBank(id, includeAccounts);

            if (bank == null)
            {
                return NotFound();
            }

            if (includeAccounts)
            {
                return Ok(_mapper.Map<BankDto>(bank));
            }

            return Ok(_mapper.Map<BankWithoutAccountsDto>(bank));
        }
    }
}
