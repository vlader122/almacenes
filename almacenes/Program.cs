using DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository;
using Service;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Ingrese el token JWT como: Bearer {token}",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<AlmacenesContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AlmacenesConnection"));
});

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AlmacenesContext>();

//repository
builder.Services.AddScoped<PersonalRepository>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<ItemRepository>();
builder.Services.AddScoped<ProveedorRepository>();
builder.Services.AddScoped<EntregaRepository>();
builder.Services.AddScoped<DetalleEntregaRepository>();

//service
builder.Services.AddScoped<PersonalService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<ProveedorService>();
builder.Services.AddScoped<EntregaService>();
builder.Services.AddScoped<DetalleEntregaService>();
builder.Services.AddScoped<FileService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AlmacenesContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My APi");
    });
}
app.MapIdentityApi<IdentityUser>();

app.UseAuthorization();

app.MapControllers();

app.Run();
