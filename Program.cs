using BlogApp.Data.Abstracts;
using BlogApp.Data.Concreate;
using BlogApp.Data.Concreate.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
});
builder.Services.AddScoped<IPostRepository, EfPostRepository>(); // IPOstRepository verildiği zaman (sanal), EfPostRepository gönderilir(gerçek versiyonundan nesne üretilip gönderilir)
builder.Services.AddScoped<ITagRepository, EfTagRepository>(); // IPOstRepository verildiği zaman (sanal), EfPostRepository gönderilir(gerçek versiyonundan nesne üretilip gönderilir)
builder.Services.AddScoped<ICommentRapository, EfCommentRepository>(); // IPOstRepository verildiği zaman (sanal), EfPostRepository gönderilir(gerçek versiyonundan nesne üretilip gönderilir)
builder.Services.AddScoped<IUserRapository, EfUserRepository>(); // IPOstRepository verildiği zaman (sanal), EfPostRepository gönderilir(gerçek versiyonundan nesne üretilip gönderilir)

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>{
    options.LoginPath="/Users/Login";
}
);
var app = builder.Build(); // wwwroot dosyalarına erişim açıldı

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

SeedData.TestVerileriniDoldur(app);
//localhost://posts/react-dersleri -->2 bölme
//localhost://posts/tag/web-programlama -->3 bölme

// url ye göre eşleştirme yapılırken sırasıyla yukarıdan aşağıya doğru şemaları gezer ilk hangiisi uyarsa o şemayı kullanır
app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/details/{url}",  // posts parantez içinde olmadığı için sabittir yalnızca url kısmı değişken
    defaults: new { controller = "Posts", action = "Details" }
);
app.MapControllerRoute(
    name: "user_profile",
    pattern: "profile/{username}",  // posts parantez içinde olmadığı için sabittir yalnızca url kısmı değişken
    defaults: new { controller = "Users", action = "Profile" }
);

app.MapControllerRoute(
    name: "posts_by_tag",
    pattern: "posts/tag/{tag}",  // posts ve tag parantez içinde olmadığı için sabittir yalnızca tag kısmı değişken
    defaults: new { controller = "Posts", action = "Index" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Posts}/{action=Index}/{id?}"
);
app.Run();
