using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Infra.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            // Usado para criar as migrações
            var connectionString =
                "Server=localhost;Port=3306;Database=dbApiCourseCsharp;Uid=root;Pwd=root";

            // var connectionString =
            //     "Server=(localdb)\\mssqllocaldb;Database=dbApiCourseCsharp;Trusted_Connection=True;MultipleActiveResultSets=true;user=sa;password=sa@123456";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseMySql (connectionString);

            // optionsBuilder.UseSqlServer (connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
