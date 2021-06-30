using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OH.Common.GroceryList.Models;

#nullable disable

namespace OH.Business.GroceryList.Database
{
    public partial class PeopleSQLitedbContext : DbContext
    {
        public PeopleSQLitedbContext()
        {
        }

        public PeopleSQLitedbContext(DbContextOptions<PeopleSQLitedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ShoppingList> ShoppingLists { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingList>(entity =>
            {
                entity.ToTable("ShoppingList");

                entity.HasIndex(e => e.Id, "IX_ShoppingList_Id")
                    .IsUnique();

                entity.Property(e => e.ItemName).IsRequired();
                

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingLists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Id, "IX_User_Id")
                    .IsUnique();

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
