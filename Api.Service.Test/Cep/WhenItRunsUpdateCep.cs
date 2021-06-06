using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class WhenItRunsUpdateCep : CepTest
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Update (Cep).")]
        public async Task ItIsPossibleToRunUpdateCep() 
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Put(cepDtoUpdate)).ReturnsAsync(cepDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(cepDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(CepId, result.Id);
            Assert.Equal(CepLogradouroUpdate, result.Logradouro);
            Assert.Equal(CepNumeroUpdate, result.Numero);
            Assert.Equal(CepCountyIdUpdate, result.CountyId);
        }
    }
}