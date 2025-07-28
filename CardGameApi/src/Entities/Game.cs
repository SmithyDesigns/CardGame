using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace CardGameApi.src.Entities
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public Deck deck;
        public Game()
        {
            Players = new List<Player>();
            deck = new Deck();
            deck.Shuffle();
        }

        public void AddPlayer(string playerName)
        {
            if (Players.Count >= 6)
            {
                throw new InvalidOperationException("Maximum players reached.");
            }
            Players.Add(new Player(playerName));
        }

        public void DealCards()
        {
            if (deck.cards.Count < 30) //@TODO check cards
            {
                throw new InvalidOperationException("Not enough cards to deal");
            }
            foreach (var player in Players)
            {
                player.Hand = deck.Deal(5);
            }
        }

        public void CalculateScores()
        {
            foreach (var player in Players)
            {
                player.CalculateScore();
            }
        }

        public void DetermineWinner()
        {
            int maxScore = Players.Max(p => p.Score);
            var winners = Players.Where(p => p.Score == maxScore).ToList();

            if (winners.Count > 1)
            {
                Console.WriteLine("It's a tie!");
                int maxSuitScore = winners.Max(p => p.SuiteScore());
                winners = winners.Where(p => p.SuiteScore() == maxSuitScore).ToList();
            }

            var winner = winners.First();
            Console.WriteLine($"The winner is {winner.Name} with a score of {winner.Score}");


            // Console.WriteLine("Winner(s):");
            // foreach (var winner in winners)
            // {
            //     Console.WriteLine($"{winner.Name} with score {winner.Score}");
            // }
        }

        public void DisplayResults()
        {
            foreach (var player in Players)
            {
                Console.WriteLine($"{player.Name}'s Cards: {string.Join(", ", player.Hand.Select(c => $"{c.Rank} of {c.Suit}"))}");
                Console.WriteLine($"{player.Name} 's Score: {player.Score}");
            }
        }


    }
}