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
    public class CardRepository : ICardRepository
    {
        private readonly GameDbContext _context;

        public CardRepository(GameDbContext context)
        {
            _context = context;
        }

        public async Task<List<Card>> GetAllCardsAsync()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task UpdateCardsInDeckStatusAsync(IEnumerable<int> cardIds, bool isInDeck)
        {
            if (cardIds == null || !cardIds.Any())
            {
                return;
            }

            var cardsToUpdate = await _context.Cards.Where(c => cardIds.Contains(c.Id)).ToListAsync();

            foreach (var card in cardsToUpdate)
            {
                card.IsInDeck = isInDeck;
            }

            await _context.SaveChangesAsync();
        }
    }
}