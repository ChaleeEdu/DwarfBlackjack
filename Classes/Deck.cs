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
        string[] suits = { "hearts", "diamonds", "clubs", "spades" };
        string[] ranks = {"a", "2", "3",  "4" , "5", "6", "7", "8", "9", "10", "j", "q", "k"};

        List<Card> cards = new List<Card>();
        public int CardsLeft => cards.Count - currentIndex;
        public bool IsEmpty => CardsLeft == 0;

        public Deck() 
        { 
            foreach(string suit in suits) // loopar igenom alla suits och ranks och skapar ett kort för varje kombination
            {
                foreach(string rank in ranks)
                {
                    Card card = new Card(suit, rank);
                    cards.Add(card);
                    
                }
            }
            Shuffle();
        }
        
        public void ResetDeck() // nollar currentIndex och shufflar om kortleken
        {
            currentIndex = 0;
            Shuffle();
        }


        public void Shuffle()
        {
            Random.Shared.Shuffle(CollectionsMarshal.AsSpan(cards)); // funktion som är inbygd i .NET 8.0 som shufflar en lista. CollectionsMarshal.AsSpan(cards) gör om listan till en span som kan shufflas.  
            foreach (Card card in cards)
            Debug.WriteLine($"{card.Suit} {card.Rank}"); // för att kolla om shuffle fungerar i debug mode
        }

        public Card DrawCard() // drar ett kort från kortleken och ökar currentIndex med 1 och returnerar gamla indexplatsen
        {
            currentIndex++;
            return cards[currentIndex-1];
        }
    }
}
