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
  public class CountyImplementation : BaseRepository<CountyEntity>, ICountyRepository
  {
    private DbSet<CountyEntity> _dataset;

    public CountyImplementation(MyContext context) : base(context)
    {
      _dataset = context.Set<CountyEntity> ();
    }

    public async Task<CountyEntity> FindCompleteByIBGE(int codeIBGE)
    {
      return await _dataset.Include(c => c.Uf)
                            .FirstOrDefaultAsync(c => c.CodeIBGE.Equals(codeIBGE));
    }

    public async Task<IEnumerable<CountyEntity>> FindCompleteByName(string name)
    {
      return await _dataset.Include(c => c.Uf).AsQueryable()
                            .Where(c => c.Name.Contains(name))
                            .ToListAsync<CountyEntity>();
    }
  }
}