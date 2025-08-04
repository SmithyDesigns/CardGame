using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGameApi.src.Entities;

namespace CardGameApi.src.Domain.Interface
{
    public interface ICardRepository
    {
        public Task<List<Card>> GetAllCardsAsync();
        public Task UpdateCardsInDeckStatusAsync(IEnumerable<int> cardIds, bool isInDeck);
    }
}