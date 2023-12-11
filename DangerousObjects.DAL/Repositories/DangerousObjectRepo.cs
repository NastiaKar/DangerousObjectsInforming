using DangerousObjectsDAL.Data;
using DangerousObjectsDAL.Entities;
using DangerousObjectsDAL.Repositories.Base;
using DangerousObjectsDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DangerousObjectsDAL.Repositories;

public class DangerousObjectRepo : BaseRepo<DangerousObject>, IDangerousObjectRepo
{
    public DangerousObjectRepo(DataContext context) : base(context) { }
    public DangerousObjectRepo(DbContextOptions<DataContext> options) : base(options) { }
    
    public override async Task<IEnumerable<DangerousObject>> GetAllAsync() => await Task.Run(() => Table.ToList());
    
    public override async Task<DangerousObject?> FindAsync(int id) => await Table.FirstOrDefaultAsync(x => x.Id == id);
    
    public override async Task<DangerousObject?> FindAsNoTrackingAsync(int id) => await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    
    public override async Task<int> AddAsync(DangerousObject entity, bool persist = true)
    {
        await Table.AddAsync(entity);
        return persist ? await SaveChangesAsync() : 0;
    }
    
    public override async Task<int> UpdateAsync(DangerousObject entity, bool persist = true)
    {
        Table.Update(entity);
        return persist ? await SaveChangesAsync() : 0;
    }
    
    public override async Task<int> DeleteAsync(DangerousObject entity, bool persist = true)
    {
        Table.Remove(entity);
        return persist ? await SaveChangesAsync() : 0;
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        Context.Dispose();
    }
}