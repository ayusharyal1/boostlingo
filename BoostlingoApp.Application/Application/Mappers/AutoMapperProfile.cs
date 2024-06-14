using AutoMapper;
using BoostlingoApp.Domain.Entities;
using BoostlingoApp.Domain.Models;

namespace BoostlingoApp.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
        }
    }
}
