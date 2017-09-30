using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GameStore.Models;
using MongoDB.Driver;

namespace GameStore.Business
{
    public class GameStorage
    {
        private readonly IMongoDatabase _mongo;

        public GameStorage(IMongoDatabase mongo)
        {
            _mongo = mongo;
        }

        private IMongoCollection<Game> GetCollection()
        {
            return _mongo.GetCollection<Game>("games");
        }

        public async Task<IList<Game>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            var cursor = await GetCollection().FindAsync(g => true, cancellationToken: ct);
            return await cursor.ToListAsync(ct);
        }

        public async Task<Game> GetByIdAsync(string id, CancellationToken ct = default(CancellationToken))
        {
            var cursor = await GetCollection().FindAsync(g => g.Id == id, cancellationToken: ct);
            return await cursor.FirstOrDefaultAsync(ct);
        }

        public Task InsertAsync(Game game, CancellationToken ct = default(CancellationToken))
        {
            return GetCollection().InsertOneAsync(game, cancellationToken: ct);
        }

        public Task<ReplaceOneResult> ReplaceAsync(Game game, CancellationToken ct = default(CancellationToken))
        {
            return GetCollection().ReplaceOneAsync(g => g.Id == game.Id, game, cancellationToken: ct);
        }

        public Task<DeleteResult> DeleteAsync(string id, CancellationToken ct = default(CancellationToken))
        {
            return GetCollection().DeleteOneAsync(g => g.Id == id, ct);
        }
    }
}
