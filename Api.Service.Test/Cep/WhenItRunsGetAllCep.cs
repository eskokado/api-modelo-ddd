using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class WhenItRunsGetAllCep : CepTest
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET All (Cep).")]
        public async Task ItIsPossibleToRunGetAllCep() 
        {
             _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listCepDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<CepDto>();
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable<CepDto>);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}