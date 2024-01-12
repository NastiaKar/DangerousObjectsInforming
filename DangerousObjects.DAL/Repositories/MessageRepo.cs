using DangerousObjectsDAL.Data;
using DangerousObjectsDAL.Entities;
using DangerousObjectsDAL.Repositories.Base;
using DangerousObjectsDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DangerousObjectsDAL.Repositories;

public class MessageRepo : BaseRepo<Message>, IMessageRepo
{
    public MessageRepo(DataContext context) : base(context) { }
    internal MessageRepo(DbContextOptions<DataContext> options) : base(options) { }
    
    public override async Task<IEnumerable<Message>> GetAllAsync() => await Task.Run(() => Table.ToList());
    
    public override async Task<Message?> FindAsync(int id) => await Table.FirstOrDefaultAsync(x => x.Id == id);
    
    public override async Task<Message?> FindAsNoTrackingAsync(int id) => await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    
    public override async Task<int> AddAsync(Message entity, bool persist = true)
    {
        await Table.AddAsync(entity);
        return persist ? await SaveChangesAsync() : 0;
    }
    
    public override async Task<int> UpdateAsync(Message entity, bool persist = true)
    {
        Table.Update(entity);
        return persist ? await SaveChangesAsync() : 0;
    }
    
    public override async Task<int> DeleteAsync(Message entity, bool persist = true)
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