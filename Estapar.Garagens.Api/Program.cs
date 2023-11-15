using Estapar.Garagens.Infrastructure.Config;
using Estapar.Garagens.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<ExternalServiceConfig>(
    builder.Configuration.GetSection("ExternalServiceConfig"));


builder.Services.AddInfrastructure(builder.Configuration);

//builder.Services.AddScoped<IFormaPagamentoService, FormaPagamentoService>();

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
