using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGameApi.src.Entities;

namespace CardGameApi.src.Domain.Interface
{
    public interface IGameRepository
    {
        public Task SaveAsync(Game game);
        public Task<List<Game>> GetGamesAsync(string? gameId, bool? isComplete = null, string? playerId = null, string? cardId = null);
        public Task UpdateGameAsync(int gameId, List<string>? playerIds = null, List<string>? cardIds = null, bool? isComplete = null);
        public Task ResetAllCardsToDeckAsync();
    }
}