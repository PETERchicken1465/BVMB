using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatVe.Models
{
    public partial class DatVeDBContent : DbContext
    {
        public DatVeDBContent()
            : base("name=DatVeDBContent")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tb_ChuyenBay> tb_ChuyenBay { get; set; }
        public virtual DbSet<tb_DatVe> tb_DatVe { get; set; }
        public virtual DbSet<tb_DoiBay> tb_DoiBay { get; set; }
        public virtual DbSet<tb_Ghe> tb_Ghe { get; set; }
        public virtual DbSet<tb_HangGhe> tb_HangGhe { get; set; }
        public virtual DbSet<tb_HoaDon> tb_HoaDon { get; set; }
        public virtual DbSet<tb_KhachHang> tb_KhachHang { get; set; }
        public virtual DbSet<tb_MayBay> tb_MayBay { get; set; }
        public virtual DbSet<tb_Nghiepvu> tb_Nghiepvu { get; set; }
        public virtual DbSet<tb_NguoiDaiDien> tb_NguoiDaiDien { get; set; }
        public virtual DbSet<tb_NhanVien> tb_NhanVien { get; set; }
        public virtual DbSet<tb_SanBay> tb_SanBay { get; set; }
        public virtual DbSet<tb_TuyenBay> tb_TuyenBay { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_ChuyenBay>()
                .HasOptional(e => e.tb_DoiBay)
                .WithRequired(e => e.tb_ChuyenBay);

            modelBuilder.Entity<tb_DoiBay>()
                .Property(e => e.CoPho)
                .IsFixedLength();

            modelBuilder.Entity<tb_Ghe>()
                .Property(e => e.DayGhe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_Ghe>()
                .HasMany(e => e.tb_DatVe)
                .WithRequired(e => e.tb_Ghe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_KhachHang>()
                .HasMany(e => e.tb_DatVe)
                .WithRequired(e => e.tb_KhachHang)
                .HasForeignKey(e => e.MaKH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_KhachHang>()
                .HasMany(e => e.tb_NguoiDaiDien)
                .WithRequired(e => e.tb_KhachHang)
                .HasForeignKey(e => e.MaKH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_NguoiDaiDien>()
                .HasMany(e => e.tb_DatVe)
                .WithOptional(e => e.tb_NguoiDaiDien)
                .HasForeignKey(e => e.MaNĐD);

            modelBuilder.Entity<tb_SanBay>()
                .HasMany(e => e.tb_TuyenBay)
                .WithOptional(e => e.tb_SanBay)
                .HasForeignKey(e => e.MaSanBayDi);

            modelBuilder.Entity<tb_SanBay>()
                .HasMany(e => e.tb_TuyenBay1)
                .WithOptional(e => e.tb_SanBay1)
                .HasForeignKey(e => e.MaSanBayDen);
        }
    }
}
