using gacha.Data;
using gacha.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<gachaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("gacha")));

//builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    //�]�wSession�W��
    options.Cookie.Name = ".adminLogin.Session";
    //�]�w�O�ɮɶ�(����)
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    //���Cookie�ܭ��n
    options.Cookie.IsEssential = true;
    // ���i�H��JS���oCookie
    options.Cookie.HttpOnly = true;
    //���w�u���HTTPS�ǰe
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});
//���UHttpContext.session(��Razor���i�H���osession)
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews(options =>
{
    //options.Filters.Add<SessionCheckFilter>(); // �������ιL�o��
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=login}/{action=login}/{id?}"
    pattern: "{controller=Home}/{action=Index}/{id?}"

    );

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id1?}/{mId?}");
});


app.Run();
