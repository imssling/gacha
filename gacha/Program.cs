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

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    //設定Session名稱
    options.Cookie.Name = ".adminLogin.Session";
    //設定逾時時間(分鐘)
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    //表示Cookie很重要
    options.Cookie.IsEssential = true;
    // 不可以用JS取得Cookie
    options.Cookie.HttpOnly = true;
    //限定只能用HTTPS傳送
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

builder.Services.AddControllersWithViews(options =>
{
    //options.Filters.Add<SessionCheckFilter>(); // 全局應用過濾器
});

//註冊HttpContext.session(讓Razor文件可以取得session)
builder.Services.AddHttpContextAccessor();
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

app.UseRouting();

app.UseAuthorization();

app.UseSession();

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
