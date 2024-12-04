using Application.Wallet;
using Application.Wallet.Mapper;
using Domain;
using Domain.Wallet;
using MongoDB.Driver;
using Repository.Wallet;
using Services.Wallet;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var databaseName = "WalletProject";
var collectionName = "wallet";

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(databaseName);
var mongoCollection = mongoDatabase.GetCollection<WalletClass>(collectionName);

builder.Services.AddSingleton(mongoCollection);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region ScropedWallet
builder.Services.AddScoped<IRepWallet, RepWallet>();
builder.Services.AddScoped<IServWallet, ServWallet>();
builder.Services.AddScoped<IAplicWallet, AplicWallet>();
builder.Services.AddScoped<IMapperWallet, MapperWallet>();
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
