using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class WhenItRunsFindCompleteByCep : CepTest
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Find Complete By Name (Cep).")]
        public async Task ItIsPossibleToRunFindCompleteByCep() 
        {
             _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.FindCompleteByCep("12345678")).ReturnsAsync(cepDto);
            _service = _serviceMock.Object;

            var result = await _service.FindCompleteByCep("12345678");
            Assert.NotNull(result);

            var _listResult = new List<CepDto>();
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.FindCompleteByCep("12345678")).Returns(Task.FromResult((CepDto) null));
            _service = _serviceMock.Object;

            var resultEmpty = await _service.FindCompleteByCep("12345678");
            Assert.Null(resultEmpty);
        }
    }
}