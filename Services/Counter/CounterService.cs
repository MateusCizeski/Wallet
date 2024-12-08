using MongoDB.Bson;
using MongoDB.Driver;

namespace Services.Counter {
    public class CounterService {
        private readonly IMongoDatabase _mongoDatabase;

        public CounterService(IMongoDatabase mongoDatabase) {
            _mongoDatabase = mongoDatabase;
        }

        public int GetNextSequenceValue(string key) {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", key);
            var update = Builders<BsonDocument>.Update.Inc("sequence_value", 1);
            var options = new FindOneAndUpdateOptions<BsonDocument> {
                ReturnDocument = ReturnDocument.After,
                IsUpsert = true
            };

            var result = _mongoDatabase.GetCollection<BsonDocument>("counters").FindOneAndUpdate(filter, update, options);

            return result["sequence_value"].AsInt32;
        }
    }
}
