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

            var userDtoCreate = new UserDtoCreate
            {
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
            };

            var userDtoUpdate = new UserDtoUpdate
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

            var userDto = Mapper.Map<UserDto>(modelToEntity);
            Assert.Equal(userDto.Id, modelToEntity.Id);
            Assert.Equal(userDto.Name, modelToEntity.Name);
            Assert.Equal(userDto.Email, modelToEntity.Email);
            Assert.Equal(userDto.CreateAt, modelToEntity.CreateAt);
            Assert.Equal(userDto.UpdateAt, modelToEntity.UpdateAt);

            var listDto = Mapper.Map<List<UserDto>>(listEntity);
            Assert.NotNull(listDto);
            Assert.True(listDto.Count() == listEntity.Count());

            var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(modelToEntity);
            Assert.Equal(userDtoCreateResult.Id, modelToEntity.Id);
            Assert.Equal(userDtoCreateResult.Name, modelToEntity.Name);
            Assert.Equal(userDtoCreateResult.Email, modelToEntity.Email);
            Assert.Equal(userDtoCreateResult.CreateAt, modelToEntity.CreateAt);

            var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(modelToEntity);
            Assert.Equal(userDtoUpdateResult.Id, modelToEntity.Id);
            Assert.Equal(userDtoUpdateResult.Name, modelToEntity.Name);
            Assert.Equal(userDtoUpdateResult.Email, modelToEntity.Email);
            Assert.Equal(userDtoUpdateResult.UpdateAt, modelToEntity.UpdateAt);

            var userModel = Mapper.Map<UserModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Name, userDto.Name);
            Assert.Equal(userModel.Email, userDto.Email);
            Assert.Equal(userModel.CreateAt, userDto.CreateAt);
            Assert.Equal(userModel.UpdateAt, userDto.UpdateAt);

 
            userModel = Mapper.Map<UserModel>(userDtoCreate);
            Assert.Equal(userModel.Name, userDtoCreate.Name);
            Assert.Equal(userModel.Email, userDtoCreate.Email);

            userModel = Mapper.Map<UserModel>(userDtoUpdate);
            Assert.Equal(userModel.Id, userDtoUpdate.Id);
            Assert.Equal(userModel.Name, userDtoUpdate.Name);
            Assert.Equal(userModel.Email, userDtoUpdate.Email);



        }
    }
}