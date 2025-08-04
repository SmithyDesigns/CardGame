using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGameApi.src.Entities;
using CardGameApi.src.Domain.Interface;
using CardGameApi.src.Domain.Repository;

namespace CardGameApi.src.Domain.Service
{
    public class CardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IPlayerRepository _playerRepository;

        public CardService(ICardRepository cardRepository, IPlayerRepository playerRepository)
        {
            _cardRepository   = cardRepository;
            _playerRepository = playerRepository;

        }

        public async Task DealCardsToPlayersAsync(List<string> playerIds, List<string> cardIds)
        {
            try
            {
                int playersCount   = playerIds.Count;
                int cardsPerPlayer = 5;

                if (cardIds.Count < playersCount * cardsPerPlayer)
                {
                    return;
                }

                await _playerRepository.UpdatePlayersWhereAsync(
                    p => playerIds.Contains(p.Id.ToString()),player =>
                    {
                        int index       = playerIds.IndexOf(player.Id.ToString());
                        var playerCards = Enumerable.Range(0, cardsPerPlayer)
                                                    .Select(i => cardIds[index + i * playersCount])
                                                    .ToArray();

                        player.CardId = playerCards.ToList();
                    }
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while dealing cards: " + ex.Message);
            }
        }
    }
}