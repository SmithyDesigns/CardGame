using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGameApi.src.Entities;
using CardGameApi.src.Domain.Interface;
using CardGameApi.src.Domain.Repository;

namespace CardGameApi.src.Domain.Service
{
    public class PlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ICardRepository _cardRepository;

        public PlayerService(IPlayerRepository playerRepository, ICardRepository cardRepository)
        {
            _playerRepository = playerRepository;
            _cardRepository   = cardRepository;
        }

        public async Task<Dictionary<string, int>> CalculateScoresForPlayersAsync(List<string> playerIds)
        {
            var allPlayers      = await _playerRepository.GetAllPlayersAsync();
            var selectedPlayers = allPlayers
                .Where(player => playerIds.Contains(player.Id.ToString()))
                .ToList();

            var allCards = await _cardRepository.GetAllCardsAsync();

            var suitValues = new Dictionary<string, int>
            {
                { "Diamonds", 1 },
                { "Hearts", 2 },
                { "Spades", 3 },
                { "Clubs", 4 }
            };


            var playerCards = selectedPlayers.ToDictionary(
                player => player.Id.ToString(),
                player => GetCardsForPlayer(player, allCards)
            );


            var baseScoresByPlayerId = playerCards.ToDictionary(
                pair => pair.Key,
                pair => CalculateSuitScore(pair.Value, suitValues)
            );


            var finalScores = ResolveFinalScores(baseScoresByPlayerId, playerCards, suitValues);

            return finalScores;
        }

        private List<Card> GetCardsForPlayer(Player player, List<Card> allCards)
        {
            return allCards.Where(c => player.CardId.Contains(c.Id.ToString())).ToList();
        }

        private int CalculateSuitScore(List<Card> cards, Dictionary<string, int> suitValues)
        {
            var suitPoints = cards
                .Select(card => suitValues.GetValueOrDefault(card.Suit, 1))
                .ToList();

            int totalScore = 1;
            foreach (var points in suitPoints)
            {
                totalScore *= points;
            }

            return totalScore;
        }
        
        private Dictionary<string, int> ResolveFinalScores(
            Dictionary<string, int> baseScoresByPlayerId,
            Dictionary<string, List<Card>> playerCards,
            Dictionary<string, int> suitValues)
        {
            var finalScores = new Dictionary<string, int>();

            foreach (var scoreGroup in baseScoresByPlayerId.GroupBy(score => score.Value))
            {
                if (scoreGroup.Count() == 1)
                {
                    var player = scoreGroup.First();
                    finalScores[player.Key] = player.Value;
                }
                else
                {
                    var recalculatedSuitScores = scoreGroup.ToDictionary(
                        player => player.Key,
                        player => CalculateSuitScore(playerCards[player.Key], suitValues)
                    );

                    var groupedBySuitScore = recalculatedSuitScores.GroupBy(p => p.Value).ToList();

                    if (groupedBySuitScore.All(g => g.Count() == 1))
                    {
                        foreach (var player in recalculatedSuitScores)
                        {
                            finalScores[player.Key] = player.Value;
                        }
                    }
                    else
                    {
                        var orderedPlayers = recalculatedSuitScores
                            .OrderByDescending(p => p.Value)
                            .ToList();

                        int baseScore = scoreGroup.Key;
                        for (int i = 0; i < orderedPlayers.Count; i++)
                        {
                            finalScores[orderedPlayers[i].Key] = baseScore - i;
                        }
                    }
                }
            }
            return finalScores;
        }
    }
}