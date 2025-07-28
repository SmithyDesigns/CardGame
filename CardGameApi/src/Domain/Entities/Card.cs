using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameApi.src.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Rank { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public Card() { }

        public Card(string rank, string suit, int value)
        {
            Rank = rank;
            Suit = suit;
            Value = value;
        }
    }
}