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
    public class ReturnUpdated
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


            var ufDtoUpdate = new UfDtoUpdate
            {
                Id = id,
                Name = name,
                Initials = initials,
            };

            var result = await _controller.Put(ufDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as UfDtoUpdateResult; 
            Assert.NotNull(resultValue);
            Assert.Equal(ufDtoUpdate.Id, resultValue.Id);
            Assert.Equal(ufDtoUpdate.Name, resultValue.Name);
            Assert.Equal(ufDtoUpdate.Initials, resultValue.Initials);
 
        }
        
    }
}