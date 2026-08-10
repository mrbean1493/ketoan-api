using ketoan.Server.Models;
using Microsoft.EntityFrameworkCore;
namespace ketoan.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<Quyen> Quyens { get; set; }
        public DbSet<NguoiDungQuyen> NguoiDungQuyens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Định nghĩa Khóa chính gồm 2 cột (NguoiDungId, QuyenId) cho bảng trung gian
            modelBuilder.Entity<NguoiDungQuyen>()
                .HasKey(nq => new { nq.NguoiDungId, nq.QuyenId });
        }
    }
}
