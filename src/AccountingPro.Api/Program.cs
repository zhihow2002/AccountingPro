using System.Reflection;
using AccountingPro.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Entity Framework
builder.Services.AddDbContext<AccountingDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        Assembly.GetExecutingAssembly(),
        typeof(AccountingPro.Application.DTOs.CompanyDto).Assembly
    );
});

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(AccountingPro.Application.DTOs.CompanyDto).Assembly);

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowBlazorApp",
        policy =>
        {
            policy
                .WithOrigins("https://localhost:7001", "http://localhost:5001")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowBlazorApp");
app.UseAuthorization();
app.MapControllers();

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AccountingDbContext>();
    context.Database.EnsureCreated();
}

app.Run();
