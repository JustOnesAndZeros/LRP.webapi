using LRP.webapi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LRP.webapi.Services;

public class LeafContext : DbContext
{
    public LeafContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
}