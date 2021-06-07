using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.County.WhenToRequestGet
{
    public class ReturnGet
    {
        private CountiesController _controller;

        [Fact(DisplayName = "É possivel realizar o Get")]
        public async Task It_is_possible_Get()
        {
            var serviceMock = new Mock<ICountyService>();
            var id = Guid.NewGuid();
            var name = Faker.Address.City();
            var codeIbge = Faker.RandomNumber.Next(10000000, 99999999);
            var ufId = Guid.NewGuid();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new CountyDto 
                { 
                    Id = id,
                    Name = name,
                    CodeIBGE = codeIbge,
                    UfId = ufId,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new CountiesController(serviceMock.Object);

            var result = await _controller.Get(id);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as CountyDto; 
            Assert.NotNull(resultValue);
            Assert.Equal(id, resultValue.Id);
            Assert.Equal(name, resultValue.Name);
            Assert.Equal(codeIbge, resultValue.CodeIBGE); 
            Assert.Equal(ufId, resultValue.UfId); 
        }
    }
}