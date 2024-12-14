using Application.Transaction;
using Application.Wallet;
using Application.WalletType;
using Domain.Transaction;
using Domain.Wallet;
using Domain.WalletType;
using Repository.Transaction;
using Repository.Wallet;
using Repository.WalletType;
using Services.Counter;
using Services.Transaction;
using Services.Wallet;
using Services.WalletType;
using MongoDB.Driver;
using Application.Wallet.Mapper;
using Application.WalletType.Mapper;
using Application.Transaction.Mapper;
using Services.Notification;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var databaseName = "WalletProject";

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(databaseName);

builder.Services.AddSingleton<IMongoDatabase>(sp =>
    mongoDatabase);

builder.Services.AddSingleton<IMongoCollection<TransactionClass>>(sp =>
    mongoDatabase.GetCollection<TransactionClass>("transaction"));

builder.Services.AddSingleton<IMongoCollection<WalletClass>>(sp =>
    mongoDatabase.GetCollection<WalletClass>("wallet"));

builder.Services.AddSingleton<IMongoCollection<WalletTypeClass>>(sp =>
    mongoDatabase.GetCollection<WalletTypeClass>("wallettype"));

builder.Services.AddScoped<IRepTransaction, RepTransaction>();
builder.Services.AddScoped<IRepWallet, RepWallet>();
builder.Services.AddScoped<IRepWalletType, RepWalletType>();

builder.Services.AddScoped<IServTransaction, ServTransaction>();
builder.Services.AddScoped<IServWallet, ServWallet>();
builder.Services.AddScoped<IServWalletType, ServWalletType>();
builder.Services.AddScoped<IServNotification, ServNotification>();

builder.Services.AddScoped<IAplicTransaction, AplicTransaction>();
builder.Services.AddScoped<IAplicWallet, AplicWallet>();
builder.Services.AddScoped<IAplicWalletType, AplicWalletType>();

builder.Services.AddScoped<CounterService>();

builder.Services.AddScoped<IMapperWallet, MapperWallet>();
builder.Services.AddScoped<IMapperWalletType, MapperWalletType>();
builder.Services.AddScoped<IMapperTransaction, MapperTransaction>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();