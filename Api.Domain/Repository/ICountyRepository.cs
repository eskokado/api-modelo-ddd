using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface ICountyRepository : IRepository<CountyEntity>
    {
         Task<CountyEntity> FindCompleteByIBGE(int codeIBGE);
         Task<IEnumerable<CountyEntity>> FindCompleteByName(string name);
    }
}