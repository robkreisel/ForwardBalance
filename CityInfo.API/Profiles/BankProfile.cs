using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API.Profiles
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<Entities.Bank, Models.BankWithoutAccountsDto>();
            CreateMap<Entities.Bank, Models.BankDto>();
        }
    }
}
