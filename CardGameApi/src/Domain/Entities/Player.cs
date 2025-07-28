using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameApi.src.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Card> Hand;
        public int GameId { get; set; }
        public Game Game { get; set; }
        
        public Player () { }

        public Player(string name)
        {
            Name = name;
            // Hand = new List<Card>();
            // Score = 0;
        }

        public void CalculateScore()
        {
            Score = Hand.Sum(card => card.Value);
        }

        public int SuiteScore()
        {
            int suiteScore = 1;
            foreach (var card in Hand)
            {
                suiteScore *= card.Suit switch
                {
                    "Diamonds" => 1,
                    "Hearts" => 2,
                    "Clubs" => 3,
                    "Spades" => 4,
                    _ => 1,
                };
            }
            return suiteScore;
        }
    }
}