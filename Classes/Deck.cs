using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace DwarfBlackjack.Classes
{
    internal class Deck
    {
        private Random random = new Random();
        int currentIndex = 0; //var i deck man tagit kort .Calle
        string[] suits = { "H", "D", "C", "S" };
        string[] ranks = {"A", "2", "3",  "4" , "5", "6", "7", "8", "9", "10", "J", "Q", "K"};

        List<Card> cards = new List<Card>();
        public Deck() 
        { 
            foreach(string suit in suits)
            {
                foreach(string rank in ranks)
                {
                    Card card = new Card(suit, rank);
                    cards.Add(card);
                    Shuffle();
                }
            }

        }

        public  void Shuffle()
        {
            Random.Shared.Shuffle(CollectionsMarshal.AsSpan(cards));
            foreach(Card card in cards)
            Debug.WriteLine($"{card.Suit} {card.Rank}");
        }
    }
}
