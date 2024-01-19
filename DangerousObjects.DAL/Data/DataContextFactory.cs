using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DangerousObjectsDAL.Data;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("data source=NASTIA\\SQLEXPRESS;database=DangerousObjects;trusted_connection=true;MultipleActiveResultSets=true");

        return new DataContext(optionsBuilder.Options);
    }
}