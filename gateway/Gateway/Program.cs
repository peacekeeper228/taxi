using Gateway.Clients;
using Gateway.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ClientsOptions>(builder.Configuration.GetSection("Clients"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddClients();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
