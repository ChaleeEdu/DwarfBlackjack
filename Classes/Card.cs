using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{

    internal class Card
    {
        public string Suit { get; private set; }
        public string Rank { get; private set; }

        public Card (string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

    }
}
