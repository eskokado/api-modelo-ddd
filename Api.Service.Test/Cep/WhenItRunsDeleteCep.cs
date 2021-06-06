using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class WhenItRunsDeleteCep : CepTest
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete (Cep).")]
        public async Task ItIsPossibleToRunDeleteCep() 
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deleted = await _service.Delete(CepId);
            Assert.True(deleted);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deleted = await _service.Delete(CepId);
            Assert.False(deleted);
        }       
    }
}