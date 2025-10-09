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
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
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

// Add Application Services
builder.Services.AddScoped<
    AccountingPro.Application.Services.ICustomerService,
    AccountingPro.Infrastructure.Services.CustomerService
>();
builder.Services.AddScoped<
    AccountingPro.Application.Services.IInvoiceService,
    AccountingPro.Infrastructure.Services.InvoiceService
>();
builder.Services.AddScoped<
    AccountingPro.Application.Services.IBillService,
    AccountingPro.Infrastructure.Services.BillService
>();
builder.Services.AddScoped<
    AccountingPro.Application.Services.IProductService,
    AccountingPro.Infrastructure.Services.ProductService
>();
builder.Services.AddScoped<
    AccountingPro.Application.Services.IDashboardService,
    AccountingPro.Application.Services.DashboardService
>();
builder.Services.AddScoped<
    AccountingPro.Application.Services.ICompanyContextService,
    AccountingPro.Application.Services.CompanyContextService
>();
builder.Services.AddScoped<
    AccountingPro.Application.Services.ICompanyService,
    AccountingPro.Infrastructure.Services.CompanyService
>();
builder.Services.AddScoped<
    AccountingPro.Application.Services.IReportService,
    AccountingPro.Infrastructure.Services.ReportService
>();
builder.Services.AddScoped<
    AccountingPro.Application.Services.IPaymentService,
    AccountingPro.Infrastructure.Services.PaymentService
>();
builder.Services.AddScoped<
    AccountingPro.Application.Services.IBalanceSheetService,
    AccountingPro.Infrastructure.Services.BalanceSheetService
>();
builder.Services.AddScoped<
    AccountingPro.Application.Services.ICountryService,
    AccountingPro.Infrastructure.Services.CountryService
>();

// Add HttpClient for API calls
builder.Services.AddHttpClient(
    "AccountingApi",
    client =>
    {
        var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7000/";
        client.BaseAddress = new Uri(apiBaseUrl);
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

    // Company context will be initialized automatically by CompanyContextService
}

await app.RunAsync();
