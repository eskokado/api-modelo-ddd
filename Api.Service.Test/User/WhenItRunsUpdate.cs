using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenItRunsUpdate : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Update.")]
        public async Task ItIsPossibleToRunUpdate() 
        {
            
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(userDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(UserId, result.Id);
            Assert.Equal(UserNameUpdate, result.Name);
            Assert.Equal(UserEmailUpdate, result.Email);
        }
        
    }
}