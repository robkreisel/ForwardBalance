using ForwardBalance.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API
{
    public class BanksDataStore
    {
        public static BanksDataStore Current { get; } = new BanksDataStore();

        public List<BankDto> Banks { get; set; }

        public BanksDataStore()
        {
            // init dummy data
            Banks = new List<BankDto>()
            {

                new BankDto()
                {
                    Id = 1,
                    Name = "Bank of America",
                    RoutingNumber = 1104585,
                    Accounts = new List<AccountDto>()
                    {
                        new AccountDto()
                        {
                            Id = 1,
                            Name = "Checking",
                            Description = "Basic checking account",
                            AccountNumber = 37544485
                        },
                        new AccountDto()
                        {
                            Id = 2,
                            Name = "Savings",
                            Description = "Basic no interest savings account",
                            AccountNumber = 87453881
                        },
                    }
                },
                new BankDto()
                {
                    Id = 2,
                    Name = "PNC Bank",
                    RoutingNumber = 569001,
                    Accounts = new List<AccountDto>()
                    {
                        new AccountDto()
                        {
                            Id = 3,
                            Name = "Checking",
                            Description = "Basic checking account",
                            AccountNumber = 37544485
                        },
                        new AccountDto()
                        {
                            Id = 4,
                            Name = "Savings",
                            Description = "Basic no interest savings account",
                            AccountNumber = 87453881
                        },
                    }
                },
                new BankDto()
                {
                    Id = 3,
                    Name = "Community America",
                    RoutingNumber = 846871,
                    Accounts = new List<AccountDto>()
                    {
                        new AccountDto()
                        {
                            Id = 5,
                            Name = "Checking",
                            Description = "Basic checking account",
                            AccountNumber = 37544485
                        },
                        new AccountDto()
                        {
                            Id = 6,
                            Name = "Savings",
                            Description = "Basic no interest savings account",
                            AccountNumber = 87453881
                        },
                    }
                }
            };
        }
    }
}
