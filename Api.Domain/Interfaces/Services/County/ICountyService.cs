using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;

namespace Api.Domain.Interfaces.Services.County
{
    public interface ICountyService
    {
         Task<CountyDto> Get (Guid id);
         Task<IEnumerable<CountyDto>> GetAll();
         Task<CountyDtoCreateResult> Post(CountyDtoCreate user);
         Task<CountyDtoUpdateResult> Put(CountyDtoUpdate user);
         Task<bool> Delete(Guid id); 
    }
}