using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LTQL.Models
{
    public partial class QLDVDbContext : DbContext
    {
        public QLDVDbContext() : base("name=QLDVDbContext")
        {
        }
        public DbSet<ChiDoan> ChiDoans { get; set; }
        public DbSet<DoanVien> DoanViens { get; set; }
        public DbSet<HoatDong> HoatDongs { get; set; }
        public DbSet<XepLoai> XepLoais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}