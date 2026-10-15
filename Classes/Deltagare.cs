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

        public int Score()
        {
            return hand.CardsValue;
        }
        public bool IsBlackjack()
        {
            return hand.IsBlackjack();
        }

        public List<Card> ShowHand()
        {
            return hand.ShowHand();
        }

        
        public int ResetHand()
        {
            int totalvalue = 0;
            return totalvalue;
        }
        
    }
}
