using EasyNetQ;
using Tick;
using TickService;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(new MessageClient(RabbitHutch.CreateBus("host=rabbitmq;port=5672;virtualhost=/;username=guest;password=guest")));
builder.Services.AddHostedService<MessagingHandler>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
