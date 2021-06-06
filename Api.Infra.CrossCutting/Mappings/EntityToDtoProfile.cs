using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.County;
using Api.Domain.Dtos.Uf;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Infra.CrossCutting.Mappings
{
    public class EntityToDtoProfile: Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UfDto, UfEntity>()
                .ReverseMap();

            CreateMap<UfDtoCreateResult, UfEntity>()
                .ReverseMap();

            CreateMap<UfDtoUpdateResult, UfEntity>()
                .ReverseMap();

            CreateMap<CountyDto, CountyEntity>()
                .ReverseMap();

            CreateMap<CountyDtoCreateResult, CountyEntity>()
                .ReverseMap();

            CreateMap<CountyDtoUpdateResult, CountyEntity>()
                .ReverseMap();

            CreateMap<CepDto, CepEntity>()
                .ReverseMap();

            CreateMap<CepDtoCreateResult, CepEntity>()
                .ReverseMap();

            CreateMap<CepDtoUpdateResult, CepEntity>()
                .ReverseMap();
        }
    }
}