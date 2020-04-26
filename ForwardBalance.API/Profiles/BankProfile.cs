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
            CreateMap<Entities.Bank, Models.BankDto>().ReverseMap();
            CreateMap<Entities.Bank, Models.BankWithoutAccountsDto>();
            CreateMap<Models.BankForCreationDto, Entities.Bank>();
        }
    }
}
