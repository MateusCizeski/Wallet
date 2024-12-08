using Application.Transaction;
using Application.Transaction.Mapper;
using Application.Wallet;
using Application.Wallet.Mapper;
using Application.WalletType;
using Application.WalletType.Mapper;
using Domain.Transaction;
using Domain.Wallet;
using Domain.WalletType;
using Infra;
using MongoDB.Driver;
using Repository.Transaction;
using Repository.Wallet;
using Repository.WalletType;
using Services.Counter;
using Services.Transaction;
using Services.Wallet;
using Services.WalletType;

var builder = WebApplication.CreateBuilder(args);

// MongoDB Configuration
var mongoConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var databaseName = "wallet";

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(databaseName);

// Registrando as coleções
builder.Services.AddSingleton(mongoDatabase.GetCollection<TransactionClass>("Transactions"));
builder.Services.AddSingleton(mongoDatabase.GetCollection<WalletClass>("Wallet"));
builder.Services.AddSingleton(mongoDatabase.GetCollection<WalletTypeClass>("WalletTypes"));

// MongoDbContext
builder.Services.AddSingleton<MongoDbContext>(sp =>
{
    return new MongoDbContext(mongoConnectionString, databaseName);
});

// Scoped Services
builder.Services.AddScoped<IRepWallet, RepWallet>();
builder.Services.AddScoped<IServWallet, ServWallet>();
builder.Services.AddScoped<IAplicWallet, AplicWallet>();
builder.Services.AddScoped<IMapperWallet, MapperWallet>();

builder.Services.AddScoped<IRepTransaction, RepTransaction>();
builder.Services.AddScoped<IServTransaction, ServTransaction>();
builder.Services.AddScoped<IAplicTransaction, AplicTransaction>();
builder.Services.AddScoped<IMapperTransaction, MapperTransaction>();

builder.Services.AddScoped<IRepWalletType, RepWalletType>();
builder.Services.AddScoped<IServWalletType, ServWalletType>();
builder.Services.AddScoped<IAplicWalletType, AplicWalletType>();
builder.Services.AddScoped<IMapperWalletType, MapperWalletType>();

// Counter Service
builder.Services.AddScoped<CounterService>();

// Swagger and controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();