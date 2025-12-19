using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AbysaltoWebAPI.Data
{
    public class ApiContextFactory : IDesignTimeDbContextFactory<ApiContext>
    {
        public ApiContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AbysaltoCart;Username=postgres;Password=monster");

            return new ApiContext(optionsBuilder.Options);
        }
    }
}
