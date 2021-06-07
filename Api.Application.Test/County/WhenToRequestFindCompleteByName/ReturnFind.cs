using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.County.WhenToRequestFindCompleteByName
{
    public class ReturnFind
    {
        private CountiesController _controller;

        [Fact(DisplayName = "É possivel realizar o GetAll")]
        public async Task It_is_possible_Find()
        {
            var serviceMock = new Mock<ICountyService>();

            serviceMock.Setup(m => m.FindCompleteByName("a")).ReturnsAsync(
                new List<CountyDto>
                {
                    new CountyDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.City(),
                        CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                        UfId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    },
                    new CountyDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.City(),
                        CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                        UfId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    },
                    new CountyDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.City(),
                        CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                        UfId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    }
                }
            );

            _controller = new CountiesController(serviceMock.Object);

            var result = await _controller.FindCompleteByName("a");
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as IEnumerable<CountyDto>; 
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count() == 3);
        }
        
    }
}