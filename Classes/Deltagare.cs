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

        public void Hit()
        {
            
        }
        
        public void Stand()
        {

        }

        public List<Card> ShowHand()
        {
            return hand.ShowHand();
        }

        public int GetTotalValue()
        {
            Card card = new Card();
            int totalvalue = totalvalue + card.GetValue();   
            return totalvalue;
        }
        public int ResetHand()
        {
            int totalvalue = 0;
            return totalvalue;
        }

    }
}
