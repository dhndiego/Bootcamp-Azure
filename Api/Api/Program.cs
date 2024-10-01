using Api.HostedServices;
using Application;
using Domain.Options;
using Infrastructure;
using Microsoft.Extensions.Azure;
using Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ServiceBusOptions>(builder.Configuration.GetSection("ServiceBusOptions"));
builder.Services.Configure<AzureOpenAIOptions>(builder.Configuration.GetSection("AzureOpenAI"));
builder.Services.AddAzureClients(options =>
{
    options.AddServiceBusClient(builder.Configuration.GetConnectionString("ServiceBusConnection"));
});

//consumer queue
//builder.Services.AddHostedService<AzureServiceBusConsumer>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructureServices();
builder.Services.AddRepository();

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
