using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;

namespace Api.Service.Test.County
{
    public class WhenItRunsCreateCounty : CountyTest
    {
        private ICountyService _service;
        private Mock<ICountyService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create. (County)")]
        public async Task ItIsPossibleToRunCreateCounty() 
        {
            
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Post(countyDtoCreate)).ReturnsAsync(countyDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(countyDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(CountyId, result.Id);
            Assert.Equal(CountyName, result.Name);
            Assert.Equal(CountyCodeIBGE, result.CodeIBGE);
            Assert.Equal(CountyUfId, result.UfId);
       }
        
    }
}