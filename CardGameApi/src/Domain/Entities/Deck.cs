using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameApi.src.Entities
{
    public class Deck
    {
        public int Id { get; set; }
        public List<Card> cards = new();
    }
}