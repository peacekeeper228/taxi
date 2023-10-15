using AuthService.Repositories;
using AuthService.Services;
using AuthService.Grpc;
using AuthService.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RedisConfig>(builder.Configuration.GetSection("Redis"));

builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpcSwagger();
builder.Services.AddGrpc()
    .AddJsonTranscoding();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddGrpc();

app.UseHttpsRedirection();

app.Run();
