using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AgroSimply_V2.Data;
using AgroSimply_V2;
using System;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AgroSimply_V2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AgroSimply_V2Context") ?? throw new InvalidOperationException("Connection string 'AgroSimply_V2Context' not found.")));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapProdutorEndpoints();

app.MapPropriedadeEndpoints();

app.MapTelefoneEndpoints();

app.MapUsuarioEndpoints();


app.UseStaticFiles();


app.UseRouting();
app.UseHttpsRedirection();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();