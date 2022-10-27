using LRP.webapi.Domain.Entities;
using LRP.webapi.Domain.Interfaces;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace LRP.webapi.Services;

public class UserRepository : IRepository<User>
{
    private readonly LeafContext _context;
    
    public UserRepository(LeafContext context)
    {
        _context = context;
    }
    
    public async Task Add(User entity)
    {
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User entity)
    {
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
    }

    public Task Patch()
    {
        throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null) return;
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetById(int id)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }

    public async Task<IEnumerable<User>> GetByQuery(Dictionary<string, string> query)
    {
        IEnumerable<User> result = new List<User>();

        foreach (KeyValuePair<string,string> keyValuePair in query)
        {
            PropertyInfo? property = typeof(User).GetProperty(keyValuePair.Key);
            if (property == null) continue;

            result = (result.Any() ? result : _context.Users).Where(x => Convert.ToString(property.GetValue(x)) == keyValuePair.Value);
        }

        return result.ToList();
    }
}