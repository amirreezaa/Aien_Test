using Aien_Test.Application.Services;
using Aien_Test.Application.Services.Interfaces;
using Aien_Test.DataAccess.Repositories;
using Aien_Test.DataAccess.Repositories.Interfaces;
using Aien_Test.WebFramework.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// Add Db context
builder.Services.AddDbContext(builder.Configuration);

// register services
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IDataInitializer, DataInitializer>();

var app = builder.Build();

// initiate database after build
app.InitializeDatabase();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

