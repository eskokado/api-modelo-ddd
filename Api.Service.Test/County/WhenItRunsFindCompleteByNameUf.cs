using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;

namespace Api.Service.Test.County
{
    public class WhenItRunsFindCompleteByNameCounty : CountyTest
    {
        private ICountyService _service;
        private Mock<ICountyService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Find Complete By Name (County).")]
        public async Task ItIsPossibleToRunFindCompleteByNameCounty() 
        {
             _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.FindCompleteByName("a")).ReturnsAsync(listCountyDto);
            _service = _serviceMock.Object;

            var result = await _service.FindCompleteByName("a");
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<CountyDto>();
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.FindCompleteByName("a")).ReturnsAsync(_listResult.AsEnumerable<CountyDto>);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.FindCompleteByName("a");
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}