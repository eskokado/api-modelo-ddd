using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.County;
using Api.Domain.Dtos.Uf;
using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Infra.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
#region User
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
#endregion

#region Uf
            CreateMap<UfModel, UfDto>().ReverseMap();
            CreateMap<UfModel, UfDtoCreate>().ReverseMap();
            CreateMap<UfModel, UfDtoUpdate>().ReverseMap();
#endregion

#region County
            CreateMap<CountyModel, CountyDto>().ReverseMap();
            CreateMap<CountyModel, CountyDtoCreate>().ReverseMap();
            CreateMap<CountyModel, CountyDtoUpdate>().ReverseMap();
#endregion

#region Cep
            CreateMap<CepModel, CepDto>().ReverseMap();
            CreateMap<CepModel, CepDtoCreate>().ReverseMap();
            CreateMap<CepModel, CepDtoUpdate>().ReverseMap();
#endregion
        }
    }
}
