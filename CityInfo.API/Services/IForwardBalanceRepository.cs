using ForwardBalance.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API.Services
{
    public interface IForwardBalanceRepository
    {
        IEnumerable<Bank> GetBanks(bool includeHidden);

        Bank GetBank(int bankId, bool includeAccounts);

        IEnumerable<Account> GetAccountsForBank(int bankId, bool includeHidden);

        Account GetAccountForBank(int bankId, int accountId);

        bool BankExists(int bankId);

        void AddBank(Bank bank);

        void AddAccountForBank(int bankId, Account account);

        void UpdateAccountForBank(int bankId, Account account);

        void DeleteAccount(Account account);

        bool Save();
    }
}
