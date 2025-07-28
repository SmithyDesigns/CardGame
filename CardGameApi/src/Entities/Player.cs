using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameApi.src.Entities
{
    public class Player
    {
        private string Name { get; set; }
        private List<Card> Hand;
        private int Score { get; set; }
        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
            Score = 0;
        }

        private void CalculateScore()
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

        public List<Card> Deal(int numberOfCards)
        {
            List<Card> dealtCards = cards.Take(numberOfCards).ToList();
            cards                 = cards.Skip(numberOfCards).ToList();

            return dealtCards;
        }
    }
}