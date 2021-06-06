using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Uf;
using Moq;
using Xunit;

namespace Api.Service.Test.Uf
{
    public class WhenItRunsCreateUf : UfTest
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create.")]
        public async Task ItIsPossibleToRunCreateUf() 
        {
            
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Post(ufDtoCreate)).ReturnsAsync(ufDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(ufDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(UfId, result.Id);
            Assert.Equal(UfName, result.Name);
            Assert.Equal(UfInitials, result.Initials);
       }
        
    }
}