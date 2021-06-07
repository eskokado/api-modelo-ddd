using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.County.WhenToRequestCreated
{
    public class ReturnBadRequest
    {
        private CountiesController _controller;

        [Fact(DisplayName = "É possivel realizar o Created")]
        public async Task It_is_possible_to_create_Created()
        {
            var serviceMock = new Mock<ICountyService>();
            var name = Faker.Address.City();
            var codeIbge = Faker.RandomNumber.Next(10000000, 99999999);
            var ufId = Guid.NewGuid();

            serviceMock.Setup(m => m.Post(It.IsAny<CountyDtoCreate>())).ReturnsAsync(
                new CountyDtoCreateResult 
                { 
                    Id = Guid.NewGuid(),
                    Name = name,
                    CodeIBGE = codeIbge,
                    UfId = ufId,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new CountiesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var countyDtoCreate = new CountyDtoCreate
            {
                Name = name,
                CodeIBGE = codeIbge,
                UfId = ufId,
            };

            var result = await _controller.Post(countyDtoCreate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}