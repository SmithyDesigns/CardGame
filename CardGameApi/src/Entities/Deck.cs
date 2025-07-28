using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameApi.src.Entities
{
    public class Deck
    {
        private List<Card> cards;
        public Deck()
        {
            cards = new List<Card>();
            InitialiseDeck();
        }

        private void InitialiseDeck()
        {
            string[] suits = { "Hearts", "Diamond", "Spades", "Clubs" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    int value = rank == "j" ? 11 : rank == "Q" ? 12 : rank == "K" ? 13 : rank == "A" ? 11 : int.Parse(rank);
                    cards.Add(new Card(rank, suit, value));
                }
            }

            cards.Add(new Card("Joker", "None", 1));
            cards.Add(new Card("Joker", "None", 1));
        }

        public void Shuffle()
        {
            Random random = new Random();
            cards         = cards.OrderBy(c => random.Next()).ToList();
        }

        public List<Card> Deal(int numberOfCards)
        {
            List<Card> dealtCards = cards.Take(numberOfCards).ToList();
            cards                 = cards.Skip(numberOfCards).ToList();

            return dealtCards;
        }
    }
}