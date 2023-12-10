using DangerousObjectsCommon.Enums;
using DangerousObjectsDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DangerousObjectsDAL.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}