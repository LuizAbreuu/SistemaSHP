using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SHP___Sociedade_Hípica_Paulista.Data;
using SHP___Sociedade_Hípica_Paulista.Services.LoginService;
using SHP___Sociedade_Hípica_Paulista.Services.NotebookDesktopService;
using SHP___Sociedade_Hípica_Paulista.Services.SenhaService;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => { 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ILoginInterface, LoginService>();
builder.Services.AddScoped<ISenhaInterface, SenhaService>();
builder.Services.AddScoped<INotebookDesktopInterface, NotebookDesktopService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Login";
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });


var app = builder.Build();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
