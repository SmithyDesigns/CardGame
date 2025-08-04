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
            _cardRepository = cardRepository;
        }

        public async Task<Dictionary<string, int>> CalculateScoresForPlayersAsync(List<string> playerIds)
        {
            var players         = await _playerRepository.GetAllPlayersAsync();
            var filteredPlayers = players.Where(p => playerIds.Contains(p.Id.ToString())).ToList();

            var allCards     = await _cardRepository.GetAllCardsAsync();
            var suitPriority = new Dictionary<string, int>
            {
                { "Spades", 4 },
                { "Hearts", 3 },
                { "Diamonds", 2 },
                { "Clubs", 1 }
            };

            var playerScores       = new Dictionary<string, int>();
            var playerSuitStrength = new Dictionary<string, int>();

            foreach (var player in filteredPlayers)
            {
                var cards               = allCards.Where(c => player.CardId.Contains(c.Id.ToString())).ToList();
                int score               = cards.Sum(c => c.Value);
                int highestSuitStrength = cards.Max(c => suitPriority.ContainsKey(c.Suit) ? suitPriority[c.Suit] : 0);

                playerScores[player.Id.ToString()] = score;
                playerSuitStrength[player.Id.ToString()] = highestSuitStrength;
            }

            var finalScores = new Dictionary<string, int>();

            foreach (var playerScore in playerScores.GroupBy(ps => ps.Value))
            {
                if (playerScore.Count() == 1)
                {
                    finalScores[playerScore.First().Key] = playerScore.Key;
                }
                else
                {
                    var orderedPlayerScores = playerScore.OrderByDescending(kv => playerSuitStrength[kv.Key]).ToList();
                    int baseScore           = playerScore.Key;
                    int penalty             = 0;

                    foreach (var orderedPlayerScore in orderedPlayerScores)
                    {
                        finalScores[orderedPlayerScore.Key] = baseScore - penalty;
                        penalty++;
                    }
                }
            }

            var winner = finalScores.OrderByDescending(kv => kv.Value).First();
            return finalScores;
        }
    }
}