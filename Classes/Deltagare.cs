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
    }
}
