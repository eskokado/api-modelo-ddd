using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Interfaces.Services.Uf
{
    public interface IUfService
    {
         
         Task<UfDto> Get (Guid id);
         Task<IEnumerable<UfDto>> GetAll();
         Task<UfDtoCreateResult> Post(UfDtoCreate user);
         Task<UfDtoUpdateResult> Put(UfDtoUpdate user);
         Task<bool> Delete(Guid id); 
    }
}