﻿using ForwardBalance.API.Contexts;
using ForwardBalance.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API.Services
{
    public class ForwardBalanceRepository : IForwardBalanceRepository
    {
        private readonly ForwardBalanceContext _context;

        public ForwardBalanceRepository(ForwardBalanceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Account GetAccountForBank(int bankId, int accountId)
        {
            return _context.Accounts
                .Where(a => a.BankId == bankId && a.Id == accountId).FirstOrDefault();
        }

        public IEnumerable<Account> GetAccountsForBank(int bankId)
        {
            return _context.Accounts
                .Where(a => a.BankId == bankId).ToList();
        }

        public Bank GetBank(int bankId, bool includeAccounts)
        {
            if (includeAccounts)
            {
                return _context.Banks.Include(b => b.Accounts)
                    .Where(b => b.Id == bankId).FirstOrDefault();
            }

            return _context.Banks
                .Where(b => b.Id == bankId).FirstOrDefault();
        }

        public IEnumerable<Bank> GetBanks()
        {
            return _context.Banks.OrderBy(b => b.Name).ToList();
        }

        public bool BankExists(int bankId)
        {
            return _context.Banks.Any(b => b.Id == bankId);
        }

        public void AddAccountForBank(int bankId, Account account)
        {
            var bank = GetBank(bankId, false);
            bank.Accounts.Add(account);
        }

        public void UpdateAccountForBank(int bankId, Account account)
        {
            var bank = GetBank(bankId, false);
            bank.Accounts.Remove(account);
        }
        
        public void DeleteAccount(Account account)
        {
            _context.Accounts.Remove(account);
        }
        
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
