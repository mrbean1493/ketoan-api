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


            // Cấu hình cho bảng ChiTietPhieuNhapXuat
            /*
            modelBuilder.Entity<ChiTietPhieuNhapXuat>(entity =>
            {
                entity.ToTable("chitietphieunhapxuat");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd(); // <--- Báo cho EF Core biết cột này do DB tự tăng khi INSERT
            });

            // Cấu hình cho bảng TonKho
            modelBuilder.Entity<TonKho>(entity =>
            {
                entity.ToTable("tonkho");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd(); // <--- Báo cho EF Core biết cột này do DB tự tăng khi INSERT
            });
            */
        }

        public DbSet<DonViTinh> DVTs { get; set; }

        public DbSet<HangHoa> HangHoas { get; set; }

        public DbSet<DoiTac> DoiTacs { get; set; }

        public DbSet<TonKho> TonKhos { get; set; }

        public DbSet<PhieuNhapXuat> PhieuNhapXuats { get; set; }
        public DbSet<ChiTietPhieuNhapXuat> ChiTietPhieuNhapXuats { get; set; }

    }
}
