using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace Data.Candidate
{
    public class CandidateService
    {
        private readonly IMongoCollection<CandidateModel> _candidates;

        public CandidateService(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _candidates = database.GetCollection<CandidateModel>("candidates");
        }

        public async Task<List<CandidateModel>> GetAsync() =>
            await _candidates.Find(candidate => true).ToListAsync();

        public async Task<CandidateModel> GetAsync(string documentNumber) =>
            await _candidates.Find(customer => customer.Document.Number == documentNumber).FirstOrDefaultAsync();

        public async Task CreateAsync(CandidateModel customer) =>
            await _candidates.InsertOneAsync(customer);

        public async Task UpdateAsync(string documentNumber, CandidateModel customerIn) =>
            await _candidates.ReplaceOneAsync(customer => customer.Document.Number == documentNumber, customerIn);

        public async Task RemoveAsync(string documentNumber) =>
            await _candidates.DeleteOneAsync(customer => customer.Document.Number == documentNumber);
    }
}
