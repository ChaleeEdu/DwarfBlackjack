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
        int currentIndex = 0; //var i deck man tagit kort
        string[] suits = { "hearts", "diamonds", "clubs", "spades" };
        string[] ranks = {"a", "2", "3",  "4" , "5", "6", "7", "8", "9", "10", "j", "q", "k"};

        List<Card> cards = new List<Card>();
        public int CardsLeft => cards.Count - currentIndex;
        public bool IsEmpty => CardsLeft == 0;

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
            Shuffle();
        }
        
        public void ResetDeck()
        {
            currentIndex = 0;
            Shuffle();
        }


        public void Shuffle()
        {
            Random.Shared.Shuffle(CollectionsMarshal.AsSpan(cards));
            foreach(Card card in cards)
            Debug.WriteLine($"{card.Suit} {card.Rank}");
        }

        public Card DrawCard()
        {
            currentIndex++;
            return cards[currentIndex-1];
        }
    }
}
