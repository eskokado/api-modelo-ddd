using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Uf.WhenToRequestCreated
{
    public class ReturnBadRequest
    {
        private UfsController _controller;

        [Fact(DisplayName = "É possivel realizar o Created")]
        public async Task It_is_possible_to_create_Created()
        {
            var serviceMock = new Mock<IUfService>();
            var name = Faker.Address.UsState();
            var initials = Faker.Address.UsStateAbbr();

            serviceMock.Setup(m => m.Post(It.IsAny<UfDtoCreate>())).ReturnsAsync(
                new UfDtoCreateResult 
                { 
                    Id = Guid.NewGuid(),
                    Name = name,
                    Initials = initials,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new UfsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var ufDtoCreate = new UfDtoCreate
            {
                Name = name,
                Initials = initials,
            };

            var result = await _controller.Post(ufDtoCreate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}