using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenItRunsCreate : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create.")]
        public async Task ItIsPossibleToRunCreate() 
        {
            
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(UserId, result.Id);
            Assert.Equal(UserName, result.Name);
            Assert.Equal(UserEmail, result.Email);
        }
        
    }
}