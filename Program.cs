﻿using Microsoft.EntityFrameworkCore;
using PCPMetalurgicaInter.Dados;
using PCPMetalurgicaInter.Models;
using PCPMetalurgicaInter.Services;

var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MySqlServerVersion(new Version(10, 5, 23));
// Add services to the container.
builder.Services.AddDbContext<BancoContext>(options => options.UseMySql(builder.Configuration
.GetConnectionString("DefaultConnection"), serverVersion));
//builder.Services.AddDbContext<BancoContext>(options => options.UseMySql(builder.Configuration
//.GetConnectionString("DefaultConnection"), serverVersion));

// Essas linhas eram necessárias para que o programa acessasse os serviços
builder.Services.AddScoped<ApontamentoService>();
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<OperacaoService>();
builder.Services.AddScoped<OperadorService>();
builder.Services.AddScoped<OrdemDeProducaoService>();
builder.Services.AddScoped<PCPService>();
builder.Services.AddScoped<PecaOperacaoService>();
builder.Services.AddScoped<PecaService>();
builder.Services.AddScoped<SubprodutoService>();
builder.Services.AddScoped<TipoDeOperacaoService>();
builder.Services.AddScoped<RepApontamento>();
builder.Services.AddScoped<RepFuncionario>();
builder.Services.AddScoped<RepOperacao>();
builder.Services.AddScoped<RepOperador>();
builder.Services.AddScoped<RepOrdemDeProducao>();
builder.Services.AddScoped<RepPCP>();
builder.Services.AddScoped<RepPeca>();
builder.Services.AddScoped<RepPecaOperacao>();
builder.Services.AddScoped<RepSubproduto>();
builder.Services.AddScoped<RepTipoDeOperacao>();


builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// 🔧 Aqui você cria o banco se ele ainda não existir
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BancoContext>();
    context.Database.EnsureCreated(); // ✅ Isso cria o banco e as tabelas definidas no OnModelCreating
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();


