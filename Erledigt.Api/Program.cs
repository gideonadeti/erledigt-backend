using Erledigt.Api.Data;
using Erledigt.Api.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ErledigtDbContext>(options =>
    options.UseInMemoryDatabase("ErledigtDb")
);

builder
    .Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<ErledigtDbContext>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Erledigt API v1");
    });
}

app.MapIdentityApi<ApplicationUser>();
app.MapControllers();
app.Run();
