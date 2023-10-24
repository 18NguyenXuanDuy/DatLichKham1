using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatLichKham.Models
{
    public partial class DLKB : DbContext
    {
        public DLKB()
            : base("name=DLKB")
        {
        }

        public virtual DbSet<BacSi> BacSi { get; set; }
        public virtual DbSet<LichKham> LichKham { get; set; }
        public virtual DbSet<PhongKham> PhongKham { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BacSi>()
                .Property(e => e.BacSi_Name)
                .IsUnicode(false);

            modelBuilder.Entity<LichKham>()
                .Property(e => e.NgayKham)
                .IsUnicode(false);

            modelBuilder.Entity<LichKham>()
                .Property(e => e.ThoiGianKham)
                .IsUnicode(false);

            modelBuilder.Entity<PhongKham>()
                .Property(e => e.PhongKham_Name)
                .IsUnicode(false);
        }
    }
}
