using TurismoApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AgenciaTurismoContext>(options =>
    options.UseSqlite("Data Source=agencia_turismo.db"));

builder.Services.AddScoped<TurismoApp.Services.ReservaService>();

// Configuração de Autenticação e Autorização
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization();

// Adicionar serviços ao contêiner
builder.Services.AddRazorPages();

var app = builder.Build();

// --- Teste do Logger ---
var logger = new TurismoApp.Models.Logger();
logger.Log("Teste de log multicast no Program.cs");

foreach (var msg in TurismoApp.Models.LogHelper.LogMemory)
{
    Console.WriteLine("Memória: " + msg);
}
// --- Fim do teste ---

// Configurar o pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();