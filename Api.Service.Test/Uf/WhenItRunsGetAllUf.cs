using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.Uf;
using Moq;
using Xunit;

namespace Api.Service.Test.Uf
{
    public class WhenItRunsGetAllUf : UfTest
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET All (Uf).")]
        public async Task ItIsPossibleToRunGetAllUf() 
        {
             _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listUfDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<UfDto>();
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable<UfDto>);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}