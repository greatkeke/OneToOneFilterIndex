using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace demo1
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Note> Notes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=dbserver; Database=demo; Persist Security Info=True;User ID=sa;Password=Coding-Changes-World;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Note>(e =>
            {
                e.HasOne(x => x.Item).WithOne(x => x.Note).HasForeignKey<Note>(x => x.ItemId);
                e.HasQueryFilter(x => !x.Deleted);
                e.HasIndex(x => x.ItemId).IsUnique().HasFilter($"[{nameof(Note.Deleted)}]=0");
            });
        }
    }
}
