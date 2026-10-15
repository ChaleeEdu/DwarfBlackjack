using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{
    internal abstract class Deltagare
    {
        public Hand hand = new Hand();

        public Deltagare()
        {

        }

        public void AddCard(Card card)
        {
            hand.AddCard(card);
        }

        
        public 
        
        public void Stand()
        {

        }

        public List<Card> ShowHand()
        {
            return hand.ShowHand();
        }

        public int Score()
        {
            return hand.CardsValue;
        }
        
    }
}
