﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatVe.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BanVeMayBayEntities : DbContext
    {
        public BanVeMayBayEntities()
            : base("name=BanVeMayBayEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tb_Ghe> tb_Ghe { get; set; }
        public virtual DbSet<tb_HangGhe> tb_HangGhe { get; set; }
        public virtual DbSet<tb_HoaDon> tb_HoaDon { get; set; }
        public virtual DbSet<tb_KhachHang> tb_KhachHang { get; set; }
        public virtual DbSet<tb_MayBay> tb_MayBay { get; set; }
        public virtual DbSet<tb_Nghiepvu> tb_Nghiepvu { get; set; }
        public virtual DbSet<tb_NhanVien> tb_NhanVien { get; set; }
        public virtual DbSet<tb_SanBay> tb_SanBay { get; set; }
        public virtual DbSet<tb_TuyenBay> tb_TuyenBay { get; set; }
        public virtual DbSet<tb_ChuyenBay> tb_ChuyenBay { get; set; }
        public virtual DbSet<tb_NguoiDaiDien> tb_NguoiDaiDien { get; set; }
        public virtual DbSet<tb_DoiBay> tb_DoiBay { get; set; }
        public virtual DbSet<tb_DatVe> tb_DatVe { get; set; }
    }
}
