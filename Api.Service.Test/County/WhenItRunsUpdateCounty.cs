using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;

namespace Api.Service.Test.County
{
    public class WhenItRunsUpdateCounty : CountyTest
    {
        private ICountyService _service;
        private Mock<ICountyService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Update (County).")]
        public async Task ItIsPossibleToRunUpdateCounty() 
        {
            
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Put(countyDtoUpdate)).ReturnsAsync(countyDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(countyDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(CountyId, result.Id);
            Assert.Equal(CountyNameUpdate, result.Name);
            Assert.Equal(CountyCodeIBGEUpdate, result.CodeIBGE);
            Assert.Equal(CountyUfIdUpdate, result.UfId);
        }
        
    }
}