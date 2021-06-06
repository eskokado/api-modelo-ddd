using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Uf;
using Moq;
using Xunit;

namespace Api.Service.Test.Uf
{
    public class WhenItRunsUpdateUf : UfTest
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Update (Uf).")]
        public async Task ItIsPossibleToRunUpdateUf() 
        {
            
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Put(ufDtoUpdate)).ReturnsAsync(ufDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(ufDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(UfId, result.Id);
            Assert.Equal(UfNameUpdate, result.Name);
            Assert.Equal(UfInitialsUpdate, result.Initials);
        }
        
    }
}