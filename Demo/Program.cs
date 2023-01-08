using Demo.EF;
using Demo.Interfaces;
using Demo.Repositories;
using Demo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionName = "DefaultConnection";
string connectionString = builder
    .Configuration
    .GetConnectionString(connectionName)
    ?? throw new InvalidOperationException($"Db connection <<{connectionName}>> not found");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => 
    options.SignIn.RequireConfirmedAccount = true)
        .AddDefaultTokenProviders()
        .AddDefaultUI()
        .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IProductService,ProductService>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout=TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly= true;
    options.Cookie.IsEssential= true;
});

//builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.UseSession();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();