using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Uf;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UfMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos (UF)")]
        public void ItIsPossibleToMapTheModelsUf()
        {

            var model = new UfModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.UsState(),
                Initials = Faker.Address.UsStateAbbr(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var modelToEntity = Mapper.Map<UfEntity>(model);
            Assert.Equal(modelToEntity.Id, model.Id);
            Assert.Equal(modelToEntity.Name, model.Name);
            Assert.Equal(modelToEntity.Initials, model.Initials);
            Assert.Equal(modelToEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelToEntity.UpdateAt, model.UpdateAt);


            var listEntity = new List<UfEntity>();
            for (int i = 0; i < 5; i++) {
                var item = new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    Initials = Faker.Address.UsStateAbbr(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listEntity.Add(item);
            }

            var listDto = Mapper.Map<List<UfDto>>(listEntity);
            Assert.NotNull(listDto);
            Assert.True(listDto.Count() == listEntity.Count());

            var dto = Mapper.Map<UfDto>(modelToEntity);
            Assert.Equal(dto.Id, modelToEntity.Id);
            Assert.Equal(dto.Name, modelToEntity.Name);
            Assert.Equal(dto.Initials, modelToEntity.Initials);
            Assert.Equal(dto.CreateAt, modelToEntity.CreateAt);
            Assert.Equal(dto.UpdateAt, modelToEntity.UpdateAt);

            var genModel = Mapper.Map<UfModel>(dto);
            Assert.Equal(genModel.Id, dto.Id);
            Assert.Equal(genModel.Name, dto.Name);
            Assert.Equal(genModel.Initials, dto.Initials);
            Assert.Equal(genModel.CreateAt, dto.CreateAt);
            Assert.Equal(genModel.UpdateAt, dto.UpdateAt);

            var dtoCreate = new UfDtoCreate
            {
                Name = Faker.Address.UsState(),
                Initials = Faker.Address.UsStateAbbr(),
            };

            genModel = Mapper.Map<UfModel>(dtoCreate);
            Assert.Equal(genModel.Name, dtoCreate.Name);
            Assert.Equal(genModel.Initials, dtoCreate.Initials);


            var dtoCreateResult = Mapper.Map<UfDtoCreateResult>(modelToEntity);
            Assert.Equal(dtoCreateResult.Id, modelToEntity.Id);
            Assert.Equal(dtoCreateResult.Name, modelToEntity.Name);
            Assert.Equal(dtoCreateResult.Initials, modelToEntity.Initials);
            Assert.Equal(dtoCreateResult.CreateAt, modelToEntity.CreateAt);


            var dtoUpdate = new UfDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.UsState(),
                Initials = Faker.Address.UsStateAbbr(),
            };

            var dtoUpdateResult = Mapper.Map<UfDtoUpdateResult>(modelToEntity);
            Assert.Equal(dtoUpdateResult.Id, modelToEntity.Id);
            Assert.Equal(dtoUpdateResult.Name, modelToEntity.Name);
            Assert.Equal(dtoUpdateResult.Initials, modelToEntity.Initials);
            Assert.Equal(dtoUpdateResult.UpdateAt, modelToEntity.UpdateAt);

            genModel = Mapper.Map<UfModel>(dtoUpdate);
            Assert.Equal(genModel.Id, dtoUpdate.Id);
            Assert.Equal(genModel.Name, dtoUpdate.Name);
            Assert.Equal(genModel.Initials, dtoUpdate.Initials);
        }
    }
}