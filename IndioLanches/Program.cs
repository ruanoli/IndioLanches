using IndioLanches.Context;
using IndioLanches.Models;
using IndioLanches.Repositories;
using IndioLanches.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Scopedd = Para cada request eu terei uma nova instancia de servi�o criada para AppDbContext.
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(mySqlConnection)); 

builder.Services.AddControllersWithViews();



builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

/*Transient: uma nova instancia do servi�o � criada a cada vez que um servi�o � 
solicitado do provedor de servi�os. Se o servi�o for descart�vel, o escopo
do servi�o monitorar� todas as inst�ncias do servi�o e destruir� todas
as inst�ncias do servi�o criadas nesse escopo quando o escopo do servi�o
for descartado
*/
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<ILancheRepository, LancheRepository>();

//Singleton significa q valer� por todo tempo de vida da minha aplica��o.
//Conseguimos obter informa��es de request, e usar os recursos do HttpContext.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Cria uma instancia do carrinho a cada request.
//Se dois clientes solicitarem o obj carrinho ao mesmo tempo, eles iram obter instancias diferentes.
builder.Services.AddScoped<CarrinhoCompra>(x => CarrinhoCompra.GetCarrinho(x));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); //agora posso armazenar os dados da sess�o.

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
