using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Entities.Account, Models.AccountDto>();
            CreateMap<Models.AccountForCreationDto, Entities.Account>();
            //CreateMap<Models.AccountForUpdateDto, Entities.Account>();
            CreateMap<Entities.Account, Models.AccountForUpdateDto>().ReverseMap();
        }
    }
}
