using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Eleted_Key.Data;
using Microsoft.AspNetCore.Identity.UI.Services; // Adăugă acest using
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Eleted_KeyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Eleted_KeyContext")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
})
.AddEntityFrameworkStores<Eleted_KeyContext>()
.AddDefaultTokenProviders()
.AddDefaultUI(); // Nu este necesară această linie dacă folosești Razor Pages

// Adaugarea serviciului pentru controller-e
builder.Services.AddControllersWithViews();

// Adăugarea serviciului pentru trimiterea de email-uri (IEmailSender)
builder.Services.AddSingleton<IEmailSender, EmailSender>(); // Înlocuiește YourEmailSenderImplementation cu clasa ta de trimitere a email-urilor


// Adăugarea serviciului pentru controller-e
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<UserManager<ApplicationUser>>();


// Adăugarea serviciului pentru paginile Razor
builder.Services.AddRazorPages();

// Adăugarea serviciului pentru trimiterea de email-uri (IEmailSender)
builder.Services.AddSingleton<IEmailSender, EmailSender>(); // Înlocuiește YourEmailSenderImplementation cu clasa ta de trimitere a email-urilor

var app = builder.Build();

// Configurarea pipeline-ului HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Configurarea rutelor pentru controller-e și pagini Razor
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.MapRazorPages();
app.Run();
