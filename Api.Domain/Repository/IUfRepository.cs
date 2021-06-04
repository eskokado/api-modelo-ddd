using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUfRepository : IRepository<UfEntity>
    {
        Task<IEnumerable<UfEntity>> FindByName(string name);
    }
}