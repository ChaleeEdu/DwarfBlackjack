using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{
    internal class Dealer : Deltagare
    {
        bool hideCard = true;
        Hand dealer = new Hand();
        Deltagare Dealer = new Deltagare();

        public void DealerDeafultHand()
        {
            Dealer.AddCard();
            Dealer.AddCard(); // hide funktionality for the dealer's second card - Alex
        }

        public void DealerPlay()
        {
            do
            {
                Dealer.Hit();
            }
            while (Dealer.GetTotalValue() < 17);
        }
    }
}
