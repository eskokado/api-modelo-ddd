using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;

namespace Api.Service.Test.County
{
    public class WhenItRunsDeleteCounty : CountyTest
    {
        private ICountyService _service;
        private Mock<ICountyService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete (County).")]
        public async Task ItIsPossibleToRunDeleteCounty() 
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deleted = await _service.Delete(CountyId);
            Assert.True(deleted);

            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deleted = await _service.Delete(CountyId);
            Assert.False(deleted);
        }       
    }
}