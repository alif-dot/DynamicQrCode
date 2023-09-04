using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QrGenerateWebApp.Models
{
    public partial class FPIDVMS2022Context : DbContext
    {
        public FPIDVMS2022Context()
        {
        }

        public FPIDVMS2022Context(DbContextOptions<FPIDVMS2022Context> options)
            : base(options)
        {
        }

        public DbSet<SellMasters> SellMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SellMasters>().HasNoKey();
        }

    }
}
