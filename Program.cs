using Application.Transaction;
using Application.Transaction.Mapper;
using Application.Wallet;
using Application.Wallet.Mapper;
using Application.WalletType;
using Application.WalletType.Mapper;
using MongoDB.Driver;
using Repository.Transaction;
using Repository.Wallet;
using Repository.WalletType;
using Services.Transaction;
using Services.Wallet;
using Services.WalletType;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var databaseName = "WalletProject";
var collectionName = "wallet";

var mongoClient = new MongoClient(mongoConnectionString);
builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddScoped(sp =>
{
    return mongoClient.GetDatabase(databaseName);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region ScopedWallet
builder.Services.AddScoped<IRepWallet, RepWallet>();
builder.Services.AddScoped<IServWallet, ServWallet>();
builder.Services.AddScoped<IAplicWallet, AplicWallet>();
builder.Services.AddScoped<IMapperWallet, MapperWallet>();
#endregion

#region ScopedWalletType
builder.Services.AddScoped<IRepWalletType, RepWalletType>();
builder.Services.AddScoped<IServWalletType, ServWalletType>();
builder.Services.AddScoped<IAplicWalletType, AplicWalletType>();
builder.Services.AddScoped<IMapperWalletType, MapperWalletType>();
#endregion

#region ScopedTransaction
builder.Services.AddScoped<IRepTransaction, RepTransaction>();
builder.Services.AddScoped<IServTransaction, ServTransaction>();
builder.Services.AddScoped<IAplicTransaction, AplicTransaction>();
builder.Services.AddScoped<IMapperTransaction, MapperTransaction>();
#endregion

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
