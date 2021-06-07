using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Uf.WhenToRequestUpdate
{
    public class ReturnBadRequest
    {
        private UfsController _controller;

        [Fact(DisplayName = "É possivel realizar o Updated")]
        public async Task It_is_possible_to_create_Updated()
        {
            var serviceMock = new Mock<IUfService>();
            var id = Guid.NewGuid();
            var name = Faker.Address.UsState();
            var initials = Faker.Address.UsStateAbbr();

            serviceMock.Setup(m => m.Put(It.IsAny<UfDtoUpdate>())).ReturnsAsync(
                new UfDtoUpdateResult 
                { 
                    Id = id,
                    Name = name,
                    Initials = initials,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new UfsController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Name", "É um campo obrigatório");


            var ufDtoUpdate = new UfDtoUpdate
            {
                Id = id,
                Name = name,
                Initials = initials,
            };

            var result = await _controller.Put(ufDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}