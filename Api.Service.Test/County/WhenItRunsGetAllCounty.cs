using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;

namespace Api.Service.Test.County
{
    public class WhenItRunsGetAllCounty : CountyTest
    {
        private ICountyService _service;
        private Mock<ICountyService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET All (County).")]
        public async Task ItIsPossibleToRunGetAllCounty() 
        {
             _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listCountyDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<CountyDto>();
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable<CountyDto>);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}