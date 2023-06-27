using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using to_do_list.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureSQL(builder.Configuration);

builder.Services.ConfigureIdentity();

builder.Services.ConfigureLifeTime();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

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

app.UseAuthorization();

// map the old route to the new route
app.MapGet("/Home/Index", context =>
{
    context.Response.Redirect("/");
    return Task.CompletedTask;
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Mission}/{action=Home}/{id?}");

app.MapRazorPages();
app.Run();
