using System.Reflection;
using AccountingPro.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

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

// Add HttpClient for API calls
builder.Services.AddHttpClient(
    "AccountingApi",
    client =>
    {
        client.BaseAddress = new Uri("https://localhost:7000/");
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Initialize database and seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AccountingDbContext>();
    
    // Apply any pending migrations
    await context.Database.MigrateAsync();
    
    // Seed initial data
    await DataSeeder.SeedDataAsync(context);
}

await app.RunAsync();
