using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EF
{
    public partial class FastFoodDBContext : DbContext
    {
        public FastFoodDBContext()
            : base("name=FastFoodDBContext")
        {
        }

        public virtual DbSet<CHITIET_HOADON> CHITIET_HOADON { get; set; }
        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHUYENMAI> KHUYENMAIs { get; set; }
        public virtual DbSet<LOAIMONAN> LOAIMONANs { get; set; }
        public virtual DbSet<MONAN> MONANs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIET_HOADON>()
                .Property(e => e.MaHD);

            modelBuilder.Entity<CHUCVU>()
                .HasMany(e => e.NHANVIENs)
                .WithRequired(e => e.CHUCVU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaHD);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CHITIET_HOADON)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHUYENMAI>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIMONAN>()
                .HasMany(e => e.MONANs)
                .WithRequired(e => e.LOAIMONAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONAN>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<MONAN>()
                .HasMany(e => e.CHITIET_HOADON)
                .WithRequired(e => e.MONAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasOptional(e => e.TAIKHOAN)
                .WithRequired(e => e.NHANVIEN);

            modelBuilder.Entity<QUYEN>()
                .HasMany(e => e.TAIKHOANs)
                .WithRequired(e => e.QUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TenTaiKhoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
