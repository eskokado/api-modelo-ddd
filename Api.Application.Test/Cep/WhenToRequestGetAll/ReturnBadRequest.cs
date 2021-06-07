using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.WhenToRequestGetAll
{
    public class ReturnBadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar o GetAll")]
        public async Task It_is_possible_GetAll
        ()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<CepDto>
                {
                    new CepDto
                    {
                        Id = Guid.NewGuid(),
                        Cep = Faker.Address.ZipCode(),
                        Logradouro = Faker.Address.StreetAddress(),
                        Numero = Faker.RandomNumber.Next(1, 99999).ToString(),
                        CountyId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    }
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Root", "Rota Inválida");


            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}