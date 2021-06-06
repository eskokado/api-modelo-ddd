using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Cep;

namespace Api.Service.Test.Cep
{
    public class CepTest
    {
        public static string CepLogradouro { get; set; }
        public static string CepNumero { get; set; }
        public static Guid CepCountyId { get; set; }
        public static string CepLogradouroUpdate { get; set; }
        public static string CepNumeroUpdate { get; set; }
        public static Guid CepCountyIdUpdate { get; set; }
        public Guid CepId { get; set; }

        public List<CepDto> listCepDto = new List<CepDto>();

        public CepDto cepDto = new CepDto();
        public CepDtoCreate cepDtoCreate = new CepDtoCreate();
        public CepDtoCreateResult cepDtoCreateResult = new CepDtoCreateResult();
        public CepDtoUpdate cepDtoUpdate = new CepDtoUpdate();
        public CepDtoUpdateResult cepDtoUpdateResult = new CepDtoUpdateResult();

        public CepTest()
        {
            CepId = Guid.NewGuid();
            CepLogradouro = Faker.Address.StreetName();
            CepNumero = Faker.Address.ZipCode();
            CepCountyId = Guid.NewGuid();
            CepLogradouroUpdate = Faker.Address.StreetName();
            CepNumeroUpdate = Faker.Address.ZipCode();
            CepCountyIdUpdate = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CepDto()
                {
                    Id = Guid.NewGuid(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.Address.ZipCode(),
                    CountyId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listCepDto.Add(dto);
            }

            cepDto = new CepDto() 
            {
                Id = CepId,
                Logradouro = CepLogradouro,
                Numero = CepNumero,
                CountyId = CepCountyId,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            cepDtoCreate = new CepDtoCreate()
            {
                Logradouro = CepLogradouro,
                Numero = CepNumero,
                CountyId = CepCountyId,
            };

            cepDtoCreateResult = new CepDtoCreateResult()
            {
                Id = CepId,
                Logradouro = CepLogradouro,
                Numero = CepNumero,
                CountyId = CepCountyId,
                CreateAt = DateTime.UtcNow,
            };

            cepDtoUpdate = new CepDtoUpdate()
            {
                Id = CepId,
                Logradouro = CepLogradouroUpdate,
                Numero = CepNumeroUpdate,
                CountyId = CepCountyIdUpdate,
            };

            cepDtoUpdateResult = new CepDtoUpdateResult()
            {
                Id = CepId,
                Logradouro = CepLogradouroUpdate,
                Numero = CepNumeroUpdate,
                CountyId = CepCountyIdUpdate,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}