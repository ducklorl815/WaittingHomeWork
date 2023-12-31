using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WaittingHomeWork.Models;
using WaittingHomeWork.Respository;
using WaittingHomeWork.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region DBList

builder.Services.Configure<DBList>(builder.Configuration.GetSection("ConnectionStrings"));

#endregion

#region Service

builder.Services.AddSingleton<ITempDataDictionaryFactory, TempDataDictionaryFactory>();
builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

builder.Services.AddSingleton<EnglishWordService>();
builder.Services.AddSingleton<HomeService>();

#endregion

#region Respository
builder.Services.AddSingleton<EnglishWordRepo>();
builder.Services.AddSingleton<HomeRepo>();

#endregion


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
