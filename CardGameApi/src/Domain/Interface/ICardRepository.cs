using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGameApi.src.Entities;

namespace CardGameApi.src.Domain.Interface
{
    public interface ICardRepository
    {
        Task<List<Card>> GetAllCardsAsync();
        Task UpdateCardsInDeckStatusAsync(IEnumerable<int> cardIds, bool isInDeck);
    }
}