using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Api.Infra.Data.Context;
using Api.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Implementations
{
  public class UfImplementation : BaseRepository<UfEntity>, IUfRepository
  {
    private DbSet<UfEntity> _dataset;

    public UfImplementation(MyContext context) : base(context)
    {
      _dataset = context.Set<UfEntity> ();
    }
    public async Task<IEnumerable<UfEntity>> FindByName(string name)
    {
      return await _dataset.AsQueryable().Where(u => u.Name.Contains(name)).ToListAsync<UfEntity>();
    }
  }
}