using DB;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AlmacenesContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AlmacenesConnection"));
});

//repository
builder.Services.AddScoped<PersonalRepository>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<ItemRepository>();

//service
builder.Services.AddScoped<PersonalService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<ItemService>();

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
}

app.UseAuthorization();

app.MapControllers();

app.Run();
