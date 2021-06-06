using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class WhenItRunsCreateCep : CepTest
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create. (Cep)")]
        public async Task ItIsPossibleToRunCreateCep() 
        {
            
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Post(cepDtoCreate)).ReturnsAsync(cepDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(cepDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(CepId, result.Id);
            Assert.Equal(CepLogradouro, result.Logradouro);
            Assert.Equal(CepNumero, result.Numero);
            Assert.Equal(CepCountyId, result.CountyId);
       }
        
    }
}