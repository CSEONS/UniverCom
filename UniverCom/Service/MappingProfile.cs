using AutoMapper;
using UniverCom.Domain.Entities;
using UniverCom.Models;

namespace UniverCom.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserViewModel>();
        }
    }
}