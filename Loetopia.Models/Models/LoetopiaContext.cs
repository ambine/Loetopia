using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Loetopia.DataAccess
{
    public partial class LoetopiaContext : DbContext
    {
        public LoetopiaContext()
        {
        }

        public LoetopiaContext(DbContextOptions<LoetopiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemAttribute> ItemAttributes { get; set; }
        public virtual DbSet<ItemImage> ItemImages { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                @"Server=ambine;Database=Loetopia;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.ToTable("Attribute");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemTypeId)
                    .HasConstraintName("FK_ItemTypeId");
            });

            modelBuilder.Entity<ItemAttribute>(entity =>
            {
                entity.ToTable("ItemAttribute");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ItemAttributes)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_AttributeId");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemAttributes)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ItemId");
            });

            modelBuilder.Entity<ItemImage>(entity =>
            {
                entity.HasKey(e => e.ItemImagesId);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemImages)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ItemImages_Item");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("ItemType");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}