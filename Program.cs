using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var databaseName = "WalletProject";
var collectionName = "wallet";

//var mongoClient = new MongoClient(mongoConnectionString);
//var mongoDatabase = mongoClient.GetDatabase(databaseName);
//var mongoCollection = mongoDatabase.GetCollection<Order>(collectionName);

//builder.Services.AddSingleton(mongoCollection);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
