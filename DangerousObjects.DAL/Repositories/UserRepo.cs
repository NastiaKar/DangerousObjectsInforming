using DangerousObjectsDAL.Data;
using DangerousObjectsDAL.Entities;
using DangerousObjectsDAL.Repositories.Base;
using DangerousObjectsDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DangerousObjectsDAL.Repositories;

public class UserRepo : BaseRepo<User>, IUserRepo
{
    public UserRepo(DataContext context) : base(context) { }
    internal UserRepo(DbContextOptions<DataContext> options) : base(options) { }

    public override async Task<IEnumerable<User>> GetAllAsync() => await Task.Run(() => Table.ToList());
    
    public override async Task<User?> FindAsync(int id) => await Table.FirstOrDefaultAsync(x => x.Id == id);
    
    public override async Task<User?> FindAsNoTrackingAsync(int id) => await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    
    public override async Task<int> AddAsync(User entity, bool persist = true)
    {
        await Table.AddAsync(entity);
        return persist ? await SaveChangesAsync() : 0;
    }
    
    public override async Task<int> UpdateAsync(User entity, bool persist = true)
    {
        Table.Update(entity);
        return persist ? await SaveChangesAsync() : 0;
    }
    
    public override async Task<int> DeleteAsync(User entity, bool persist = true)
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
    
    public async Task<User?> FindByEmailAsync(string email)
    {
        return await Table
            .Where(x => x.Email == email).FirstOrDefaultAsync();
    }
    
    public async Task<User?> FindByIdAsync(int id)
    {
        return await Table
            .Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}