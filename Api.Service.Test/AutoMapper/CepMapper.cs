using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CepMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos (Cep)")]
        public void ItIsPossibleToMapTheModelsCep()
        {
            var model = new CepModel
            {
                Id = Guid.NewGuid(),
                Logradouro = Faker.Address.StreetAddress(),
                Cep = Faker.Address.ZipCode(),
                CountyId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var modelToEntity = Mapper.Map<CepEntity>(model);
            Assert.Equal(modelToEntity.Id, model.Id);
            Assert.Equal(modelToEntity.Logradouro, model.Logradouro);
            Assert.Equal(modelToEntity.Cep, model.Cep);
            Assert.Equal(modelToEntity.CountyId, model.CountyId);
            Assert.Equal(modelToEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelToEntity.UpdateAt, model.UpdateAt);

            var entity = new CepEntity
            {
                Id = Guid.NewGuid(),
                Logradouro = Faker.Address.StreetAddress(),
                Cep = Faker.Address.ZipCode(),
                CountyId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                County = new CountyEntity
                {
                    Id = Guid.NewGuid(),
                    CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                    Name = Faker.Address.City()
                }
            };


            var listEntity = new List<CepEntity>();
            for (int i = 0; i < 5; i++) {
                var item = new CepEntity
                {
                    Id = Guid.NewGuid(),
                    Logradouro = Faker.Address.StreetAddress(),
                    Cep = Faker.Address.ZipCode(),
                    CountyId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    County = new CountyEntity
                    {
                        Id = Guid.NewGuid(),
                        CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                        Name = Faker.Address.City()
                    }
                };
                listEntity.Add(item);
            }

            var listDto = Mapper.Map<List<CepDto>>(listEntity);
            Assert.NotNull(listDto);
            Assert.True(listDto.Count() == listEntity.Count());

            var dto = Mapper.Map<CepDto>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Logradouro, entity.Logradouro);
            Assert.Equal(dto.Cep, entity.Cep);
            Assert.Equal(dto.CountyId, entity.CountyId);
            Assert.Equal(dto.CreateAt, entity.CreateAt);
            Assert.Equal(dto.UpdateAt, entity.UpdateAt);
            Assert.Equal(dto.County.Id, entity.County.Id);
            Assert.Equal(dto.County.CodeIBGE, entity.County.CodeIBGE);
            Assert.Equal(dto.County.Name, entity.County.Name);

            var genModel = Mapper.Map<CepModel>(dto);
            Assert.Equal(genModel.Id, dto.Id);
            Assert.Equal(genModel.Logradouro, dto.Logradouro);
            Assert.Equal(genModel.Cep, dto.Cep);
            Assert.Equal(genModel.CountyId, dto.CountyId);
            Assert.Equal(genModel.CreateAt, dto.CreateAt);
            Assert.Equal(genModel.UpdateAt, dto.UpdateAt);

            var dtoCreate = new CepDtoCreate
            {
                Logradouro = Faker.Address.StreetAddress(),
                Cep = Faker.Address.ZipCode(),
                CountyId = Guid.NewGuid(),
            };

            genModel = Mapper.Map<CepModel>(dtoCreate);
            Assert.Equal(genModel.Logradouro, dtoCreate.Logradouro);
            Assert.Equal(genModel.Cep, dtoCreate.Cep);
            Assert.Equal(genModel.CountyId, dtoCreate.CountyId);

            var dtoCreateResult = Mapper.Map<CepDtoCreateResult>(entity);
            Assert.Equal(dtoCreateResult.Id, entity.Id);
            Assert.Equal(dtoCreateResult.Logradouro, entity.Logradouro);
            Assert.Equal(dtoCreateResult.Cep, entity.Cep);
            Assert.Equal(dtoCreateResult.CountyId, entity.CountyId);
            Assert.Equal(dtoCreateResult.CreateAt, entity.CreateAt);
            Assert.Equal(dtoCreateResult.County.Id, entity.County.Id);
            Assert.Equal(dtoCreateResult.County.CodeIBGE, entity.County.CodeIBGE);
            Assert.Equal(dtoCreateResult.County.Name, entity.County.Name);

            var dtoUpdate = new CepDtoUpdate
            {
                Id = Guid.NewGuid(),
                Logradouro = Faker.Address.StreetAddress(),
                Cep = Faker.Address.ZipCode(),
                CountyId = Guid.NewGuid(),
            };

            var dtoUpdateResult = Mapper.Map<CepDtoUpdateResult>(entity);
            Assert.Equal(dtoUpdateResult.Id, entity.Id);
            Assert.Equal(dtoUpdateResult.Logradouro, entity.Logradouro);
            Assert.Equal(dtoUpdateResult.Cep, entity.Cep);
            Assert.Equal(dtoUpdateResult.CountyId, entity.CountyId);
            Assert.Equal(dtoUpdateResult.UpdateAt, entity.UpdateAt);
            Assert.Equal(dtoUpdateResult.County.Id, entity.County.Id);
            Assert.Equal(dtoUpdateResult.County.CodeIBGE, entity.County.CodeIBGE);
            Assert.Equal(dtoUpdateResult.County.Name, entity.County.Name);

            genModel = Mapper.Map<CepModel>(dtoUpdate);
            Assert.Equal(genModel.Id, dtoUpdate.Id);
            Assert.Equal(genModel.Logradouro, dtoUpdate.Logradouro);
            Assert.Equal(genModel.Cep, dtoUpdate.Cep);
            Assert.Equal(genModel.CountyId, dtoUpdate.CountyId);
        }
    }
}