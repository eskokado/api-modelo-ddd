using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;

namespace Api.Service.Test.County
{
    public class WhenItRunsGetCounty : CountyTest     
    {
        private ICountyService _service;
        private Mock<ICountyService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET (County).")]
        public async Task ItIsPossibleToRunGetCounty() 
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Get(CountyId)).ReturnsAsync(countyDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(CountyId);
            Assert.NotNull(result);
            Assert.True(result.Id == CountyId);
            Assert.Equal(result.Name, CountyName);
            Assert.Equal(result.CodeIBGE, CountyCodeIBGE);
            Assert.Equal(result.UfId, CountyUfId);

            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CountyDto) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(CountyId);
            Assert.Null(_record);
        }
    }
}