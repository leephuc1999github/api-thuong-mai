using api.Models;
using library.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace library
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<NhanVienDaiDien> NhanVienDaiDiens { get; set; }
        public DbSet<NhanVienQuanLy> NhanVienQuanLys { get; set; }
        public DbSet<NhanVienBaoVe> NhanVienBaoVes { get; set; } 
        

        public DbSet<DoiTac> DoiTacs { get; set; }

        public DbSet<HopDong> HopDongs { get; set; }
        
        public DbSet<CuaHang> CuaHangs { get; set; }

        public DbSet<TinhThanh> TinhThanhs { get; set;}

        public DbSet<Mua> Muas { get; set; }

        public DbSet<MatHang> MatHangs { get; set; }

        public DbSet<KinhDoanh> KinhDoanhs { get; set; }

        public DbSet<KhachHang> KhachHangs { get; set; }

        public DbSet<GiamSat> GiamSats { get; set; }

        public DbSet<ChiNhanh> ChiNhanhs { get; set; }

        public DbSet<GiamDoc> GiamDocs { get; set; }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entity in entities)
            {
                var obj = entity.Entity;
                if (entity.State == EntityState.Added)
                {
                    obj.GetType().GetProperty("Created").SetValue(obj,DateTime.Now);
                    obj.GetType().GetProperty("CreatedBy").SetValue(obj, "Phuc");
                }
                else
                {
                    obj.GetType().GetProperty("Modified").SetValue(obj, DateTime.Now);
                    obj.GetType().GetProperty("ModifiedBy").SetValue(obj, "Phuc");
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<NhanVien>().ToTable("NhanViens");
            
            builder.Entity<DoiTac>().ToTable("DoiTacs");
            builder.Entity<HopDong>().ToTable("HopDongs");
            builder.Entity<CuaHang>().ToTable("CuaHangs");
            builder.Entity<TinhThanh>().ToTable("TinhThanhs");
            builder.Entity<Mua>().ToTable("Muas");
            builder.Entity<MatHang>().ToTable("MatHangs");
            builder.Entity<KinhDoanh>().ToTable("KinhDoanhs");
            builder.Entity<KhachHang>().ToTable("KhachHangs");
            builder.Entity<GiamSat>().ToTable("GiamSats");
            builder.Entity<ChiNhanh>().ToTable("ChiNhanhs");
            builder.Entity<GiamDoc>().ToTable("GiamDocs");


            base.OnModelCreating(builder);
        }

    }
     
}
