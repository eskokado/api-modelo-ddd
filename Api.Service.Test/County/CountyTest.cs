using System;
using System.Collections.Generic;
using Api.Domain.Dtos.County;

namespace Api.Service.Test.County
{
    public class CountyTest
    {
        public static string CountyName { get; set; }
        public static int CountyCodeIBGE { get; set; }
        public static Guid CountyUfId { get; set; }
        public static string CountyNameUpdate { get; set; }
        public static int CountyCodeIBGEUpdate { get; set; }
        public static Guid CountyUfIdUpdate { get; set; }
        public Guid CountyId { get; set; }

        public List<CountyDto> listCountyDto = new List<CountyDto>();

        public CountyDto countyDto = new CountyDto();
        public CountyDtoCreate countyDtoCreate = new CountyDtoCreate();
        public CountyDtoCreateResult countyDtoCreateResult = new CountyDtoCreateResult();
        public CountyDtoUpdate countyDtoUpdate = new CountyDtoUpdate();
        public CountyDtoUpdateResult countyDtoUpdateResult = new CountyDtoUpdateResult();

        public CountyTest()
        {
            CountyId = Guid.NewGuid();
            CountyName = Faker.Name.FullName();
            CountyCodeIBGE = Faker.RandomNumber.Next(10000000, 99999999);
            CountyUfId = Guid.NewGuid();
            CountyNameUpdate = Faker.Name.FullName();
            CountyCodeIBGEUpdate = Faker.RandomNumber.Next(10000000, 99999999);
            CountyUfIdUpdate = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CountyDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                    UfId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listCountyDto.Add(dto);
            }

            countyDto = new CountyDto() 
            {
                Id = CountyId,
                Name = CountyName,
                CodeIBGE = CountyCodeIBGE,
                UfId = CountyUfId,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            countyDtoCreate = new CountyDtoCreate()
            {
                Name = CountyName,
                CodeIBGE = CountyCodeIBGE,
                UfId = CountyUfId,
            };

            countyDtoCreateResult = new CountyDtoCreateResult()
            {
                Id = CountyId,
                Name = CountyName,
                CodeIBGE = CountyCodeIBGE,
                UfId = CountyUfId,
                CreateAt = DateTime.UtcNow,
            };

            countyDtoUpdate = new CountyDtoUpdate()
            {
                Id = CountyId,
                Name = CountyNameUpdate,
                CodeIBGE = CountyCodeIBGEUpdate,
                UfId = CountyUfIdUpdate,
            };

            countyDtoUpdateResult = new CountyDtoUpdateResult()
            {
                Id = CountyId,
                Name = CountyNameUpdate,
                CodeIBGE = CountyCodeIBGEUpdate,
                UfId = CountyUfIdUpdate,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}