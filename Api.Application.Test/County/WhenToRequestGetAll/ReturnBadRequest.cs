using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.County.WhenToRequestGetAll
{
    public class ReturnBadRequest
    {
        private CountiesController _controller;

        [Fact(DisplayName = "É possivel realizar o GetAll")]
        public async Task It_is_possible_GetAll
        ()
        {
            var serviceMock = new Mock<ICountyService>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
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
                    }
                }
            );

            _controller = new CountiesController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Root", "Rota Inválida");


            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}