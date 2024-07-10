using dotnet_nine_webapi.Services;
using dotnet_nine.Features;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<InvestmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapSwagger();

app.MapGet("/", () => "Investment API");
app.MapGet("/error", () => TypedResults.InternalServerError("An error occurred while processing your request."));

app.MapGet("/investments", () =>
{
    var service = app.Services.GetRequiredService<InvestmentService>();
    return service.GetInvestments();
});

app.MapGet("/investments/{symbol}", (string symbol) =>
{
    var service = app.Services.GetRequiredService<InvestmentService>();
    return service.GetInvestment(symbol);
});

app.MapPost("/investments", (Investment investment) =>
{
    var service = app.Services.GetRequiredService<InvestmentService>();
    service.CreateInvestment(investment);
    return Results.Created($"/investments/{investment.Symbol}", investment);
});

app.MapPut("/investments/{symbol}", (string symbol, Investment investment) =>
{
    var service = app.Services.GetRequiredService<InvestmentService>();
    service.UpdateInvestment(symbol, investment);
    return Results.NoContent();
});

app.MapDelete("/investments/{symbol}", (string symbol) =>
{
    var service = app.Services.GetRequiredService<InvestmentService>();
    service.DeleteInvestment(symbol);
    return Results.NoContent();
});

app.MapGet("/investments/total", () =>
{
    var service = app.Services.GetRequiredService<InvestmentService>();
    return service.CalculateTotalInvestment();
});

app.MapGet("/investments/total/{symbol}", (string symbol) =>
{
    var service = app.Services.GetRequiredService<InvestmentService>();
    return service.CalculateTotalInvestment(symbol);
});

app.MapGet("/investments/stocks", () =>
{
    var service = app.Services.GetRequiredService<InvestmentService>();
    return service.GetStocks();
});

app.MapGet("/investments/bonds", () =>
{
    var service = app.Services.GetRequiredService<InvestmentService>();
    return service.GetBonds();
});

app.Run();