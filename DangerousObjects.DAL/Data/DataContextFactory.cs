using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DangerousObjectsDAL.Data;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=DangerousObjects;Trusted_Connection=True;MultipleActiveResultSets=true");

        return new DataContext(optionsBuilder.Options);
    }
}