using Microsoft.EntityFrameworkCore;
using Teammate.Data.Entities;

namespace Teammate.Data.Context;

public static class ModelsConfigure
{
  public static void AddConfigures(ModelBuilder modelBuilder)
  {

    modelBuilder.Entity<SportCategoryEntity>().HasKey(c => c.Id);
    modelBuilder.Entity<SportCategoryEntity>()
        .HasMany(c => c.SportTypes)
        .WithOne(c => c.SportCategory)
        .HasForeignKey(c => c.CategoryFID);

    modelBuilder.Entity<SportTypeEntity>().HasKey(c => c.Id);
    modelBuilder.Entity<SportTypeEntity>()
        .HasMany(c => c.SportLookups)
        .WithOne(c => c.SportType)
        .HasForeignKey(c=>c.SportTypeFID);
    modelBuilder.Entity<SportTypeEntity>()
        .HasOne(c => c.SportCategory)
        .WithMany(c => c.SportTypes);

    modelBuilder.Entity<SportLookupEntity>().HasKey(c => c.Id);
    modelBuilder.Entity<SportLookupEntity>()
        .HasOne(c => c.SportType)
        .WithMany(c => c.SportLookups);
    modelBuilder.Entity<SportLookupEntity>()
        .HasOne(c => c.LookupCategory)
        .WithMany(c => c.SportLookups);
    modelBuilder.Entity<SportLookupEntity>()
        .HasOne(c => c.User)
        .WithMany(c => c.SportLookups)
        .HasForeignKey(c=>c.UserFID);


    modelBuilder.Entity<LookupCategoryEntity>().HasKey(c => c.Id);
    modelBuilder.Entity<LookupCategoryEntity>()
        .HasMany(c => c.SportLookups)
        .WithOne(c => c.LookupCategory)
        .HasForeignKey(c=>c.LookupCategoryFID);

    modelBuilder.Entity<TeammateUserEntity>().HasKey(c => c.Id);
    modelBuilder.Entity<TeammateUserEntity>()
        .HasOne(c => c.AccountUser)
        .WithOne(c => c.User)
        .HasForeignKey<TeammateUserEntity>(c=>c.AccountFID);
    modelBuilder.Entity<TeammateUserEntity>()
      .HasMany(c => c.SendedMessages)
      .WithOne(c => c.SenderUser)
      .OnDelete(DeleteBehavior.Cascade);
    modelBuilder.Entity<TeammateUserEntity>()
     .HasMany(c => c.ReceivedMessages)
     .WithOne(c => c.RecipientUser)
     .OnDelete(DeleteBehavior.Cascade);


    modelBuilder.Entity<MessageEntity>().HasKey(c => c.Id);
    modelBuilder.Entity<MessageEntity>()
        .HasOne(c => c.SenderUser)
        .WithMany(c => c.SendedMessages)
        .HasForeignKey(c=>c.SenderFID)
        .OnDelete(DeleteBehavior.NoAction);
    modelBuilder.Entity<MessageEntity>()
        .HasOne(c => c.RecipientUser)
        .WithMany(c => c.ReceivedMessages)
        .HasForeignKey(c=>c.RecipientFID)
        .OnDelete(DeleteBehavior.NoAction);
    
  }
}

