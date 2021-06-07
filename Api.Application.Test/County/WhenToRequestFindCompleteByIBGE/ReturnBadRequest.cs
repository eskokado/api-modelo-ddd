using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.County.WhenToRequestFindCompleteByIbge
{
    public class ReturnBadRequest
    {
        private CountiesController _controller;

        [Fact(DisplayName = "É possivel realizar o Get")]
        public async Task It_is_possible_Get
        ()
        {
            var serviceMock = new Mock<ICountyService>();
            var id = Guid.NewGuid();
            var name = Faker.Address.City();
            var codeIbge = Faker.RandomNumber.Next(10000000, 99999999);
            var ufId = Guid.NewGuid();

            serviceMock
            .Setup(m => m.FindCompleteByIBGE(codeIbge)).ReturnsAsync(
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
            _controller
                .ModelState
                .AddModelError("Id", "Registro inexistente");


            var result = await _controller.FindCompleteByIBGE(codeIbge);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}