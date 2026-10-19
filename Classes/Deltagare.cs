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
        public bool IsBlackjack() // kollar om handen är blackjack
        {
            return hand.IsBlackjack(); 
        }
        
        public bool IsBust() // kollar om handen är bust
        {
            return hand.IsBust();
        }

        public List<Card> ShowHand()
        {
            return hand.ShowHand();
        }

        
        public void ResetHand()
        {
            hand = new Hand();
        }

        

        public bool Has21()
        {
            return hand.Has21();
        }
        
    }
}
