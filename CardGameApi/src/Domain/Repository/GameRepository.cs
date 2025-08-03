using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGameApi.src.Domain.Interface;
using CardGameApi.src.Domain.Data;
using CardGameApi.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardGameApi.src.Domain.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly GameDbContext _context;

        public GameRepository(GameDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Game>> GetGamesAsync(string? gameId, bool? isComplete = null, string? playerId = null, string? cardId = null)
        {
            var query = _context.Games.AsQueryable();

            if (string.IsNullOrWhiteSpace(gameId))
            {
                query = query.Where(g => g.Id.Equals(gameId));
            }

            if (isComplete.HasValue)
            {
                query = query.Where(g => g.isComplete == isComplete.Value);
            }


            if (!string.IsNullOrEmpty(playerId))
            {
                query = query.Where(g => g.PlayerId.Contains(playerId));
            }

            if (!string.IsNullOrEmpty(cardId))
            {
                query = query.Where(g => g.CardId.Contains(cardId));
            }

            return await query.ToListAsync();
        }

        public async Task UpdateGameAsync(int gameId, List<string>? playerIds = null, List<string>? cardIds = null, bool? isComplete = null)
        {
            var game = await _context.Games.FindAsync(gameId);
            if (game == null)
            {
                return;
            }

            if (playerIds != null)
                game.PlayerId = playerIds;

            if (cardIds != null)
                game.CardId = cardIds;

            if (isComplete.HasValue)
                game.isComplete = isComplete;

            await _context.SaveChangesAsync();
        }
        
        public async Task ResetAllCardsToDeckAsync()
        {
            var allCards = await _context.Cards.ToListAsync();

            foreach (var card in allCards)
            {
                card.IsInDeck = true;
            }

            await _context.SaveChangesAsync();
        }
    }
}