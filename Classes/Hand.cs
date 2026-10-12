using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{

    internal class Hand
    {
        List<Card> cards = new List<Card>();
        public int CardsValue { get; set; }

        bool isBust = false;
        
        


        public Hand()
        {

        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public void CalculateCount()
        {
            int aceCount = 0;
        }

        public List<Card> ShowHand()
        {
            return cards;
        }

    }
}
