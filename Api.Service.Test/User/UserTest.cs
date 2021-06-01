using System;
using System.Collections.Generic;
using Api.Domain.Dtos.User;

namespace Api.Service.Test.User
{
    public class UserTest
    {
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserNameUpdate { get; set; }
        public static string UserEmailUpdate { get; set; }
        public Guid UserId { get; set; }

        public List<UserDto> listUserDto = new List<UserDto>();

        public UserDto userDto = new UserDto();
        public UserDtoCreate userDtoCreate = new UserDtoCreate();
        public UserDtoCreateResult userDtoCreateResult = new UserDtoCreateResult();
        public UserDtoUpdate userDtoUpdate = new UserDtoUpdate();
        public UserDtoUpdateResult userDtoUpdateResult = new UserDtoUpdateResult();

        public UserTest()
        {
            UserId = Guid.NewGuid();
            UserName = Faker.Name.FullName();
            UserEmail = Faker.Internet.Email();
            UserNameUpdate = Faker.Name.FullName();
            UserEmailUpdate = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listUserDto.Add(dto);
            }

            userDto = new UserDto() 
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            userDtoCreate = new UserDtoCreate()
            {
                Name = UserName,
                Email = UserEmail
            };

            userDtoCreateResult = new UserDtoCreateResult()
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                CreateAt = DateTime.UtcNow
            };

            userDtoUpdate = new UserDtoUpdate()
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail
            };

            userDtoUpdateResult = new UserDtoUpdateResult()
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}