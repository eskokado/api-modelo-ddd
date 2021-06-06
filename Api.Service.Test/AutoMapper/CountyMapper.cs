using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.County;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CountyMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos (County)")]
        public void ItIsPossibleToMapTheModelsCounty()
        {
            var model = new CountyModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                UfId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            var modelToEntity = Mapper.Map<CountyEntity>(model);
            Assert.Equal(modelToEntity.Id, model.Id);
            Assert.Equal(modelToEntity.Name, model.Name);
            Assert.Equal(modelToEntity.CodeIBGE, model.CodeIBGE);
            Assert.Equal(modelToEntity.UfId, model.UfId);
            Assert.Equal(modelToEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelToEntity.UpdateAt, model.UpdateAt);

            var entity = new CountyEntity
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                UfId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                Uf = new UfEntity{
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    Initials = Faker.Address.UsStateAbbr()
                }
            };


            var listEntity = new List<CountyEntity>();
            for (int i = 0; i < 5; i++) {
                var item = new CountyEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.City(),
                    CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                    UfId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Uf = new UfEntity{
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.UsState(),
                        Initials = Faker.Address.UsStateAbbr()
                    }
                };
                listEntity.Add(item);
            }

            var listDto = Mapper.Map<List<CountyDto>>(listEntity);
            Assert.NotNull(listDto);
            Assert.True(listDto.Count() == listEntity.Count());

            var dto = Mapper.Map<CountyDto>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Name, entity.Name);
            Assert.Equal(dto.CodeIBGE, entity.CodeIBGE);
            Assert.Equal(dto.UfId, entity.UfId);
            Assert.Equal(dto.CreateAt, entity.CreateAt);
            Assert.Equal(dto.UpdateAt, entity.UpdateAt);
            Assert.Equal(dto.Uf.Id, entity.Uf.Id);
            Assert.Equal(dto.Uf.Name, entity.Uf.Name);
            Assert.Equal(dto.Uf.Initials, entity.Uf.Initials);

            var genModel = Mapper.Map<CountyModel>(dto);
            Assert.Equal(genModel.Id, dto.Id);
            Assert.Equal(genModel.Name, dto.Name);
            Assert.Equal(genModel.CodeIBGE, dto.CodeIBGE);
            Assert.Equal(genModel.UfId, dto.UfId);
            Assert.Equal(genModel.CreateAt, dto.CreateAt);
            Assert.Equal(genModel.UpdateAt, dto.UpdateAt);

            var dtoCreate = new CountyDtoCreate
            {
                Name = Faker.Address.City(),
                CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                UfId = Guid.NewGuid(),
            };

            genModel = Mapper.Map<CountyModel>(dtoCreate);
            Assert.Equal(genModel.Name, dtoCreate.Name);
            Assert.Equal(genModel.CodeIBGE, dtoCreate.CodeIBGE);
            Assert.Equal(genModel.UfId, dtoCreate.UfId);

            var dtoCreateResult = Mapper.Map<CountyDtoCreateResult>(entity);
            Assert.Equal(dtoCreateResult.Id, entity.Id);
            Assert.Equal(dtoCreateResult.Name, entity.Name);
            Assert.Equal(dtoCreateResult.CodeIBGE, entity.CodeIBGE);
            Assert.Equal(dtoCreateResult.UfId, entity.UfId);
            Assert.Equal(dtoCreateResult.CreateAt, entity.CreateAt);
            Assert.Equal(dtoCreateResult.Uf.Id, entity.Uf.Id);
            Assert.Equal(dtoCreateResult.Uf.Name, entity.Uf.Name);
            Assert.Equal(dtoCreateResult.Uf.Initials, entity.Uf.Initials);

            var dtoUpdate = new CountyDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                UfId = Guid.NewGuid(),
            };

            var dtoUpdateResult = Mapper.Map<CountyDtoUpdateResult>(entity);
            Assert.Equal(dtoUpdateResult.Id, entity.Id);
            Assert.Equal(dtoUpdateResult.Name, entity.Name);
            Assert.Equal(dtoUpdateResult.CodeIBGE, entity.CodeIBGE);
            Assert.Equal(dtoUpdateResult.UfId, entity.UfId);
            Assert.Equal(dtoUpdateResult.UpdateAt, entity.UpdateAt);
            Assert.Equal(dtoUpdateResult.Uf.Id, entity.Uf.Id);
            Assert.Equal(dtoUpdateResult.Uf.Name, entity.Uf.Name);
            Assert.Equal(dtoUpdateResult.Uf.Initials, entity.Uf.Initials);

            genModel = Mapper.Map<CountyModel>(dtoUpdate);
            Assert.Equal(genModel.Id, dtoUpdate.Id);
            Assert.Equal(genModel.Name, dtoUpdate.Name);
            Assert.Equal(genModel.CodeIBGE, dtoUpdate.CodeIBGE);
            Assert.Equal(genModel.UfId, dtoUpdate.UfId);
        }
    }
}