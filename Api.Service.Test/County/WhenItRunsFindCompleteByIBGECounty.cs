using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;

namespace Api.Service.Test.County
{
    public class WhenItRunsFindCompleteByIBGECounty : CountyTest
    {
        private ICountyService _service;
        private Mock<ICountyService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Find Complete By Name (County).")]
        public async Task ItIsPossibleToRunFindCompleteByIBGECounty() 
        {
             _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.FindCompleteByIBGE(1234)).ReturnsAsync(countyDto);
            _service = _serviceMock.Object;

            var result = await _service.FindCompleteByIBGE(1234);
            Assert.NotNull(result);

            var _listResult = new List<CountyDto>();
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.FindCompleteByIBGE(1234)).Returns(Task.FromResult((CountyDto) null));
            _service = _serviceMock.Object;

            var resultEmpty = await _service.FindCompleteByIBGE(1234);
            Assert.Null(resultEmpty);
        }
    }
}