using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{

    internal class Card
    {
        public string Suit { get; private set; }
        public string Rank { get; private set; }

        public string ImageSource {  get; private set; }

        public Card (string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
            ImageSource = $"card_{Suit}_{Rank}.png";

        }
        public int GetValue()
        {
            return Rank switch
            {
                "2" => 2,
                "3" => 3,
                "4" => 4,
                "5" => 5,
                "6" => 6,
                "7" => 7,
                "8" => 8,
                "9" => 9,
                "10" => 10,
                "J" => 10,
                "Q" => 10,
                "K" => 10,
                "A" => 11, // Ändrar string till ett numeriskt värde
                 _  => int.Parse(Rank)
            };

        }
    }

}
