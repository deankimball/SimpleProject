var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Application dependencies
builder.Services.AddScoped<Agdata.Api.Services.Interfaces.IGetProfile, Agdata.Api.Services.GetProfile>();
builder.Services.AddScoped<Agdata.Api.Services.Interfaces.ISaveProfile, Agdata.Api.Services.SaveProfile>();

builder.Services.AddScoped<Agdata.Infrastructure.Repositories.IRepository<Agdata.Domain.Entities.Profile>, Agdata.Infrastructure.Repositories.ProfileRepository>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
