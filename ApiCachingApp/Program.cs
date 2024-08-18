using ApiCachingApp.Data;
using ApiCachingApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("SampleDbConnection");
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApiDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI
builder.Services.AddScoped<ICacheService, CacheService>();
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
