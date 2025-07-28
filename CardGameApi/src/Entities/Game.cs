using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace CardGameApi.src.Entities
{
    public class Game
    {
        public List<Player> players;
        public Deck deck;
        public Game()
        {
            players = new List<Player>();
            deck = new Deck();
            deck.Shuffle();
        }

        public void AddPlayer(string name)
        {
            players.Add(new Player(name));
        }

        public void DealCards()
        {
            foreach (var player in players)
            {
                player.Hand = deck.Deal(5);
            }
        }

        public void CalculateScores()
        {
            foreach (var player in players)
            {
                player.CalculateScore();
            }
        }

        public void DetermineWinner()
        {
            int maxScore = players.Max(p => p.Score);
            var winners = players.Where(p => p.Score == maxScore).ToList();

            if (winners.Count > 1)
            {
                Console.WriteLine("It's a tie!");
                int maxSuitScore = winners.Max(p => p.SuiteScore());
                winners = winners.Where(p => p.SuiteScore() == maxSuitScore).ToList();
            }

            Console.WriteLine("Winner(s):");
            foreach (var winner in winners)
            {
                Console.WriteLine($"{winner.Name} with score {winner.Score}");
            }
        }

        public void DisplayResults()
        {
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}'s Cards: {string.Join(", ", player.Hand.Select(c => $"{c.Rank} of {c.Suit}"))}");
                Console.WriteLine($"{player.Name} 's Score: {player.Score}");
            }
        }


    }
}