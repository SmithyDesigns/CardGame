using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using CardGameApi.src.Entities;
using CardGameApi.src.Domain.Service;
using CardGameApi.src.Domain.Interface;

namespace CardGameApi.src.Domain.Service
{
    // public class GameService
    // {

    //     private readonly IGameRepository _repository;
    //     private readonly DeckService _deckService;

    //     public GameService(IGameRepository repository)
    //     {
    //         _repository = repository;
    //     }

    //     public async Task<Game> StartGameAsync()
    //     {
    //         var game = new Game
    //         {
    //             Players = new List<Player>(),
    //             // Cards = new List<Card>()
    //         };

    //         // _repository.Games.Add(game);
    //         // await _context.SaveChangesAsync();

    //         return await _repository.CreateGameAsync(game);
        
    //     }

    //     private static void Shuffle(List<Card> cards)
    //     {
    //         var random = new Random();
    //         int cardCount = cards.Count;
    //         while (cardCount > 1)
    //         {
    //             cardCount--;
    //             int k = random.Next(cardCount + 1);
    //             var temp = cards[k];
    //             cards[k] = cards[cardCount];
    //             cards[cardCount] = temp;
    //         }
    //     }





    //     public void AddPlayer(Player playerName)
    //     {
    //         _game.AddPlayer(playerName);
    //     }

    //     public void DealCards()
    //     {
    //         if (_game.Deck.cards.Count < _game.Players.Count * 5)
    //             throw new InvalidOperationException("Not enough cards to deal.");

    //         foreach (var player in _game.Players)
    //         {
    //             player.Hand = _deckService.Deal(5);
    //         }
    //     }

    //     public void CalculateScores()
    //     {
    //         foreach (var player in _game.Players)
    //         {
    //             player.CalculateScore();
    //         }
    //     }

    //     public Player DetermineWinner()
    //     {
    //         var maxScore = _game.Players.Max(p => p.Score);
    //         var winners = _game.Players.Where(p => p.Score == maxScore).ToList();

    //         if (winners.Count > 1)
    //         {
    //             var maxSuitScore = winners.Max(p => p.SuiteScore());
    //             winners = winners.Where(p => p.SuiteScore() == maxSuitScore).ToList();
    //         }

    //         return winners.First();
    //     }

    //     public string GetResults()
    //     {
    //         var result = new StringBuilder();
    //         foreach (var player in _game.Players)
    //         {
    //             var hand = string.Join(", ", player.Hand.Select(c => $"{c.Rank} of {c.Suit}"));
    //             result.AppendLine($"{player.Name}'s Cards: {hand}");
    //             result.AppendLine($"{player.Name}'s Score: {player.Score}");
    //         }
    //         return result.ToString();
    //     }
    // }
}