using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.County.WhenToRequestUpdate
{
    public class ReturnBadRequest
    {
        private CountiesController _controller;

        [Fact(DisplayName = "É possivel realizar o Updated")]
        public async Task It_is_possible_to_create_Updated()
        {
            var serviceMock = new Mock<ICountyService>();
            var id = Guid.NewGuid();
            var name = Faker.Address.City();
            var codeIbge = Faker.RandomNumber.Next(10000000, 99999999);
            var ufId = Guid.NewGuid();

            serviceMock.Setup(m => m.Put(It.IsAny<CountyDtoUpdate>())).ReturnsAsync(
                new CountyDtoUpdateResult 
                { 
                    Id = id,
                    Name = name,
                    CodeIBGE = codeIbge,
                    UfId = ufId,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new CountiesController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Name", "É um campo obrigatório");


            var countyDtoUpdate = new CountyDtoUpdate
            {
                Id = id,
                Name = name,
                CodeIBGE = codeIbge,
                UfId = ufId,
            };

            var result = await _controller.Put(countyDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}