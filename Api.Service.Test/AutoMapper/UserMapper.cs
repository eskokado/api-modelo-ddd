using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UserMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos")]
        public void ItIsPossibleToMapTheModels()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listEntity = new List<UserEntity>();
            for (int i = 0; i < 5; i++) {
                var item = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listEntity.Add(item);
            }

            var dtoCreate = new UserDtoCreate
            {
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
            };

            var dtoUpdate = new UserDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
            };

            var modelToEntity = Mapper.Map<UserEntity>(model);
            Assert.Equal(modelToEntity.Id, model.Id);
            Assert.Equal(modelToEntity.Name, model.Name);
            Assert.Equal(modelToEntity.Email, model.Email);
            Assert.Equal(modelToEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelToEntity.UpdateAt, model.UpdateAt);

            var dto = Mapper.Map<UserDto>(modelToEntity);
            Assert.Equal(dto.Id, modelToEntity.Id);
            Assert.Equal(dto.Name, modelToEntity.Name);
            Assert.Equal(dto.Email, modelToEntity.Email);
            Assert.Equal(dto.CreateAt, modelToEntity.CreateAt);
            Assert.Equal(dto.UpdateAt, modelToEntity.UpdateAt);

            var listDto = Mapper.Map<List<UserDto>>(listEntity);
            Assert.NotNull(listDto);
            Assert.True(listDto.Count() == listEntity.Count());

            var dtoCreateResult = Mapper.Map<UserDtoCreateResult>(modelToEntity);
            Assert.Equal(dtoCreateResult.Id, modelToEntity.Id);
            Assert.Equal(dtoCreateResult.Name, modelToEntity.Name);
            Assert.Equal(dtoCreateResult.Email, modelToEntity.Email);
            Assert.Equal(dtoCreateResult.CreateAt, modelToEntity.CreateAt);

            var dtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(modelToEntity);
            Assert.Equal(dtoUpdateResult.Id, modelToEntity.Id);
            Assert.Equal(dtoUpdateResult.Name, modelToEntity.Name);
            Assert.Equal(dtoUpdateResult.Email, modelToEntity.Email);
            Assert.Equal(dtoUpdateResult.UpdateAt, modelToEntity.UpdateAt);

            var genModel = Mapper.Map<UserModel>(dto);
            Assert.Equal(genModel.Id, dto.Id);
            Assert.Equal(genModel.Name, dto.Name);
            Assert.Equal(genModel.Email, dto.Email);
            Assert.Equal(genModel.CreateAt, dto.CreateAt);
            Assert.Equal(genModel.UpdateAt, dto.UpdateAt);

 
            genModel = Mapper.Map<UserModel>(dtoCreate);
            Assert.Equal(genModel.Name, dtoCreate.Name);
            Assert.Equal(genModel.Email, dtoCreate.Email);

            genModel = Mapper.Map<UserModel>(dtoUpdate);
            Assert.Equal(genModel.Id, dtoUpdate.Id);
            Assert.Equal(genModel.Name, dtoUpdate.Name);
            Assert.Equal(genModel.Email, dtoUpdate.Email);



        }
    }
}