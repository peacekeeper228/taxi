using Gateway.Clients;
using Gateway.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ClientsOptions>(builder.Configuration.GetSection("Clients"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
    setup.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Gateway.xml"))
);
builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddClients();

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseCors(options => options
    .WithOrigins(new string[] { "*", })
    .AllowAnyHeader()
    .AllowAnyMethod());

app.Run();
