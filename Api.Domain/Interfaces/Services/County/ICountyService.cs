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
         Task<CountyDtoCreateResult> Post(CountyDtoCreate county);
         Task<CountyDtoUpdateResult> Put(CountyDtoUpdate county);
         Task<bool> Delete(Guid id); 
         Task<CountyDto> FindCompleteByIBGE(int codeIBGE);
         Task<IEnumerable<CountyDto>> FindCompleteByName(string name);

    }
}