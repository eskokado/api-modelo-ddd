using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class WhenItRunsGetCep : CepTest     
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET (Cep).")]
        public async Task ItIsPossibleToRunGetCep() 
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(CepId)).ReturnsAsync(cepDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(CepId);
            Assert.NotNull(result);
            Assert.True(result.Id == CepId);
            Assert.Equal(result.Logradouro, CepLogradouro);
            Assert.Equal(result.Numero, CepNumero);
            Assert.Equal(result.CountyId, CepCountyId);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(CepId);
            Assert.Null(_record);
        }
    }
}