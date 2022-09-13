using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teammate.Data.Entities;

namespace Teammate.Data.Context;

public class ApplicationDbContext : IdentityDbContext<AccountUser>
{
  public ApplicationDbContext(DbContextOptions options) : base(options)
  {

  }

  public DbSet<SportCategoryEntity> SportCategory { get; set; }
  public DbSet<LookupCategoryEntity> LookupCategory { get; set; }
  public DbSet<SportLookupEntity> SportLookup { get; set; }
  public DbSet<SportTypeEntity> SportType { get; set; }
  public DbSet<MessageEntity> Message { get; set; }
  public DbSet<TeammateUserEntity> TeammateUser { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    ModelsConfigure.AddConfigures(modelBuilder);
    base.OnModelCreating(modelBuilder);
  }
}

