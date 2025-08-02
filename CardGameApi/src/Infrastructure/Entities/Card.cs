using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardGameApi.src.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Rank { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public bool IsInDeck { get; set; } = true;
        public int DeckNumber { get; set; }
    }
}