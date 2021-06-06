using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Uf;
using Moq;
using Xunit;

namespace Api.Service.Test.Uf
{
    public class WhenItRunsDeleteUf : UfTest
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete (Uf).")]
        public async Task ItIsPossibleToRunDeleteUf() 
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deleted = await _service.Delete(UfId);
            Assert.True(deleted);

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deleted = await _service.Delete(UfId);
            Assert.False(deleted);
        }       
    }
}