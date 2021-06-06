using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Uf;

namespace Api.Service.Test.Uf
{
    public class UfTest
    {
        public static string UfName { get; set; }
        public static string UfInitials { get; set; }
        public static string UfNameUpdate { get; set; }
        public static string UfInitialsUpdate { get; set; }
        public Guid UfId { get; set; }

        public List<UfDto> listUfDto = new List<UfDto>();

        public UfDto ufDto = new UfDto();
        public UfDtoCreate ufDtoCreate = new UfDtoCreate();
        public UfDtoCreateResult ufDtoCreateResult = new UfDtoCreateResult();
        public UfDtoUpdate ufDtoUpdate = new UfDtoUpdate();
        public UfDtoUpdateResult ufDtoUpdateResult = new UfDtoUpdateResult();

        public UfTest()
        {
            UfId = Guid.NewGuid();
            UfName = Faker.Address.UsState();
            UfInitials = Faker.Address.UsStateAbbr();
            UfNameUpdate = Faker.Address.UsState();
            UfInitialsUpdate = Faker.Address.UsStateAbbr();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UfDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    Initials = Faker.Address.UsStateAbbr(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listUfDto.Add(dto);
            }

            ufDto = new UfDto() 
            {
                Id = UfId,
                Name = UfName,
                Initials = UfInitials,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            ufDtoCreate = new UfDtoCreate()
            {
                Name = UfName,
                Initials = UfInitials,
            };

            ufDtoCreateResult = new UfDtoCreateResult()
            {
                Id = UfId,
                Name = UfName,
                Initials = UfInitials,
                CreateAt = DateTime.UtcNow,
            };

            ufDtoUpdate = new UfDtoUpdate()
            {
                Id = UfId,
                Name = UfName,
                Initials = UfInitials,
            };

            ufDtoUpdateResult = new UfDtoUpdateResult()
            {
                Id = UfId,
                Name = UfNameUpdate,
                Initials = UfInitialsUpdate,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}