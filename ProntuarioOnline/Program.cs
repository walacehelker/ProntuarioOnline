using AutoMapper;
using Configuration;
using Domain.Identity;
using Enuns;
using InjectionDependency;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using ProntuarioOnline.Mappings;
using Implementations.Identity;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// DbContext do Identity
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
QuestPDF.Settings.License = LicenseType.Community;

// Identity com suporte a Roles
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
  options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddErrorDescriber<PortugueseIdentityErrorDescriber>()
.AddDefaultTokenProviders();

// 🔹 Configura o caminho da tela de login
builder.Services.ConfigureApplicationCookie(options =>
{
  options.LoginPath = "/Identity/Account/Login";
});

// 🔹 Adiciona filtro global exigindo autenticação
builder.Services.AddRazorPages(options =>
{
  // Aqui você pode configurar rotas se precisar
})
.AddMvcOptions(options =>
{
  var policy = new AuthorizationPolicyBuilder()
      .RequireAuthenticatedUser()
      .Build();
  options.Filters.Add(new AuthorizeFilter(policy));
});

// DbContext da aplicação
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.MigrationsAssembly("Configuration")
    )
);

// AutoMapper
var configExpression = new MapperConfigurationExpression();
configExpression.AddProfile<MappingProfile>();

var mapperConfig = new MapperConfiguration(configExpression);

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Injeção de dependências customizadas
builder.Services.AddProjectDependencies();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
  app.UseMigrationsEndPoint();
}
else
{
  app.UseExceptionHandler("/Error");
  app.UseHsts();
}

// Seed de usuário admin
async Task SeedUserAsync(WebApplication app)
{
  using var scope = app.Services.CreateScope();
  var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
  var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

  if (!await roleManager.RoleExistsAsync("Admin"))
    await roleManager.CreateAsync(new IdentityRole("Admin"));

  var email = "admin@teste.com";
  var password = "SenhaForte@123";

  if (await userManager.FindByEmailAsync(email) == null)
  {
    var user = new ApplicationUser
    {
      UserName = email,
      Email = email,
      EmailConfirmed = true,
      TipoUsuario = TipoUsuario.Admin
    };
    var result = await userManager.CreateAsync(user, password);
    if (result.Succeeded)
      await userManager.AddToRoleAsync(user, "Admin");
    else
    {
      foreach (var error in result.Errors)
        Console.WriteLine($"Erro ao criar usuário: {error.Description}");
    }
  }
}

await SeedUserAsync(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // 🔹 Necessário para login funcionar
app.UseAuthorization();

app.MapRazorPages();

app.Run();