using APIK8S.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIK8S.Services
{
    public class QuoteService
    {
        private readonly IMongoCollection<Quote> _quoteCollection;

        public QuoteService(
            IOptions<QuoteStoreDatabaseSettings> quoteStoreDatabaseSettings)
        {
            //"mongodb://root:password1234@apik8s-mongo:27017",
            var baseUrl = "mongodb://";
            var user = quoteStoreDatabaseSettings.Value.User;
            var pwd = quoteStoreDatabaseSettings.Value.Pwd;
            var dbUrl = quoteStoreDatabaseSettings.Value.DbUrl;

            var connectionString = $"{baseUrl}{user}:{pwd}@{dbUrl}";
            var mongoClient = new MongoClient(connectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                quoteStoreDatabaseSettings.Value.DatabaseName);

            _quoteCollection = mongoDatabase.GetCollection<Quote>(
                quoteStoreDatabaseSettings.Value.QuoteCollectionName);
        }

        public async Task<List<Quote>> GetAsync() =>
          await _quoteCollection.Find(_ => true).ToListAsync();

        public async Task<Quote> GetRandomQuote(){
            var quoteList =await  GetAsync();
            var random = new Random();
            int idx = random.Next(quoteList.Count);
            return quoteList[idx];
        }
           

     }


}
