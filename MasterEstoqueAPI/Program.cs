using MasterEstoqueAPI.Business.Services;
using MasterEstoqueAPI.Data.Infra;
using MasterEstoqueAPI.Data.Repository;
using MasterEstoqueAPI.Domain.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region ..:: Dependences Injection ::..
// Services
builder.Services.AddScoped<IMasterEstoqueAPIService, MasterEstoqueAPIService>();
// Repository
builder.Services.AddScoped<IMasterEstoqueAPIRepository, MasterEstoqueAPIRepository>();
// DB Context
builder.Services.AddScoped<IDbContext, DbContext>();
#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();