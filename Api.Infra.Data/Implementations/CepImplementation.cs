using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Api.Infra.Data.Context;
using Api.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Implementations
{
  public class CepImplementation : BaseRepository<CepEntity>, ICepRepository
  {
    private DbSet<CepEntity> _dataset;

    public CepImplementation(MyContext context) : base(context)
    {
      _dataset = context.Set<CepEntity> ();
    }

    public async Task<CepEntity> FindCompleteByCep(string cep)
    {
      return await _dataset.Include(c => c.County)
                            .ThenInclude(cy => cy.Uf)
                            .SingleOrDefaultAsync(c => c.Cep.Equals(cep));
    }
  }
}