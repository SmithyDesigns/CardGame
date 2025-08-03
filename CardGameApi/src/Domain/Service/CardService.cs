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
            _cardRepository = cardRepository;
            _playerRepository = playerRepository;

        }

        public async Task DealCardsToPlayersAsync(List<string> playerIds, List<string> cardIds)
        {
            try
            {
                int playersCount = playerIds.Count;
                int cardsPerPlayer = 5;

                if (cardIds.Count < playersCount * cardsPerPlayer)
                    return;

                await _playerRepository.UpdatePlayersWhereAsync(
                    p => playerIds.Contains(p.Id.ToString()),player =>
                    {
                        int index = playerIds.IndexOf(player.Id.ToString());

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
        //     public List<Card> cards = new();
        //     public void Deck()
        //     {
        //         InitialiseDeck();
        //     }

        //     private void InitialiseDeck()
        //     {
        //         string[] suits = { "Hearts", "Diamond", "Spades", "Clubs" };
        //         string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        //         foreach (string suit in suits)
        //         {
        //             foreach (string rank in ranks)
        //             {
        //                 int value = rank == "j" ? 11 : rank == "Q" ? 12 : rank == "K" ? 13 : rank == "A" ? 11 : int.Parse(rank);
        //                 cards.Add(new Card(rank, suit, value));
        //             }
        //         }

        //         cards.Add(new Card("Joker", "None", 1));
        //         cards.Add(new Card("Joker", "None", 1));
        //     }

        //     public void Shuffle()
        //     {
        //         Random random = new Random();
        //         for (int i = cards.Count - 1; i > 0; i--)
        //         {
        //             int j = random.Next(i + 1);
        //             (cards[i], cards[j]) = (cards[j], cards[i]);
        //         }
        //     }

        //     public List<Card> Deal(int numberOfCards)
        //     {
        //         if (cards.Count < numberOfCards)
        //         {
        //             throw new InvalidOperationException("Not enough cards to deal.");
        //         }

        //         List<Card> dealtCards = cards.Take(numberOfCards).ToList();
        //         cards = cards.Skip(numberOfCards).ToList();

        //         return dealtCards;
        //     }

        // public int RemainingCards(Deck deck)
        // {
        //     return deck.cards.Count;
        // }
    }
}