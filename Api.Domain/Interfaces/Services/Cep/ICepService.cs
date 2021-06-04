using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;

namespace Api.Domain.Interfaces.Services.Cep
{
    public interface ICepService
    {
         Task<CepDto> Get (Guid id);
         Task<IEnumerable<CepDto>> GetAll();
         Task<CepDtoCreateResult> Post(CepDtoCreate user);
         Task<CepDtoUpdateResult> Put(CepDtoUpdate user);
         Task<bool> Delete(Guid id); 
    }
}