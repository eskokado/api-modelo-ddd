using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenItRunsFindByLogin : LoginTest
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método FindByLogin.")]
        public async Task ItIsPossibleToRunFindByLogin() 
        {
            var objectReturn = new 
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                accessToken = Guid.NewGuid(),
                userName = loginDto.Email,
                name = Faker.Name.FullName(),
                message = "Usuário logado com sucesso"
            };
            
            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objectReturn);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
            Assert.True(objectReturn.authenticated);
            Assert.Equal(loginDto.Email, objectReturn.userName);
        }        
    }
}