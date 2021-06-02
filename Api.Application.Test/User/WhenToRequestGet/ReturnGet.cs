using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.WhenToRequestGet
{
    public class ReturnGet
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar o Get")]
        public async Task It_is_possible_Get()
        {
            var serviceMock = new Mock<IUserService>();
            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto 
                { 
                    Id = id,
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Get(id);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as UserDto; 
            Assert.NotNull(resultValue);
            Assert.Equal(id, resultValue.Id);
            Assert.Equal(name, resultValue.Name);
            Assert.Equal(email, resultValue.Email);
 
        }
        
    }
}