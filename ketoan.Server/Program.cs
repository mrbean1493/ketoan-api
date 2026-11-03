using ketoan.Server.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký DbContext PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm dịch vụ Controller & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Bật Swagger UI để kiểm tra API
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage(); // Giúp hiển thị chi tiết lỗi màu đỏ thay vì chỉ báo lỗi 500 chung chung
    app.UseSwagger();
    app.UseSwaggerUI();
}
//tạm comment khi đang chạy trên local/test
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();