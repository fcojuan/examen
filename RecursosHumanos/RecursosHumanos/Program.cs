using AccesoDatos.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Negocio.Interfaces;
using Rinku.Data;
using Rinku.Service;
using Rinku.Service.IService;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<MenuService>();

//// Add services to the container.
var sqlConecctionConfig = new DapperContext(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton(sqlConecctionConfig);

////------------Register dapper in scope
builder.Services.AddScoped<IDapperService, DapperService>();
builder.Services.AddScoped(typeof(IGeneral<>), typeof(General<>));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//--------------------manejo de las imagenes
builder.Services.AddScoped<IArchivoUnpload,ArchivoUnpload>();  
//---- para los usuarios
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
//--------------------------

builder.Services.AddScoped<AuthenticationStateProvider, Rinku.Areas.RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//------------------DevExpress
builder.Services.AddDevExpressBlazor();
builder.Services.AddDevExpressServerSideBlazorReportViewer();
//-----------
// Add Identity  Order = 1 !important
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option => {
//    option.Password.RequireDigit = true;
//    option.Password.RequiredUniqueChars = 5;
//    option.Password.RequireLowercase = false;
//    option.Password.RequireNonAlphanumeric = false;
//    option.Password.RequireUppercase = false;
//    option.Password.RequiredLength = 16;
//}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// Database Contexts Order = 2 !important
//builder.Services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Transient);

//3 : Cookie Options  
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
options.MinimumSameSitePolicy = SameSiteMode.None;
});
//la comprobación de si el usuario está conectado ocurre ~cada 10 segundos
builder.Services.Configure<SecurityStampValidatorOptions>(options => options.ValidationInterval = TimeSpan.FromSeconds(5));

//Establecer la página de inicio de sesión de la cuenta 
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Identity/Account/AccessDenied"; /*"/Error/AccessDenied"*/;
    options.Cookie.Name = "MyAPP";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    //options.LoginPath = "/";
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});
builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder("Cookies").RequireAuthenticatedUser().Build();
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".MyAPP.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//.AddCookie(options =>
//{
//    options.ExpireTimeSpan = TimeSpan.FromDays(2);
//});

//-----DevExpress
builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();
//----------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var supportedCultures = new[] { new CultureInfo("es-MX") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("es-MX"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession(); //use una memoria caché para almacenar los datos de la sesión.

//app.MapControllers();
//app.MapBlazorHub();

app.MapBlazorHub(option =>
{
    option.CloseOnAuthenticationExpiration = true; //Esta opcion se usa para habilitar el seguimiento de la caducidad de 
                                                   //la autenticacion,que cerrar las conexiones cuando caduque un token
});

app.MapFallbackToPage("/_Host");

app.Run();
