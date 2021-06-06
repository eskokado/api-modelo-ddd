using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.Uf;
using Moq;
using Xunit;

namespace Api.Service.Test.Uf
{
    public class WhenItRunsGetUf : UfTest     
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET (Uf).")]
        public async Task ItIsPossibleToRunGetUf() 
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(UfId)).ReturnsAsync(ufDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(UfId);
            Assert.NotNull(result);
            Assert.True(result.Id == UfId);
            Assert.Equal(result.Name, UfName);
            Assert.Equal(result.Initials, UfInitials);

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UfDto) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(UfId);
            Assert.Null(_record);
        }
    }
}