using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ardelean_Daria_Labb2.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<Ardelean_Daria_Labb2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ardelean_Daria_Labb2Context") ?? throw new InvalidOperationException("Connection string 'Ardelean_Daria_Labb2Context' not found.")));
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryIdentityContextConnection")
 ?? throw new InvalidOperationException("Connection string 'LibraryIdentityContextConnection' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddAuthorization(options =>
{ 
    options.AddPolicy("AdminPolicy", policy => 
   policy.RequireRole("Admin")); 
});


//Add services to the container
builder.Services.AddRazorPages(options =>
{
    //  permite acces doar utilizatorilor autentificați în folderul /Books
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");

    //Cerinta 1
    options.Conventions.AuthorizeFolder("/Publishers", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Categories", "AdminPolicy");


});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
