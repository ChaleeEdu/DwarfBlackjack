using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{
    internal class Dealer : Deltagare
    {
        bool hideCard = true;
        Hand dealer = new Hand();
        Deltagare deltagare = new Deltagare();

        public void DealerPlay()
        {
            do
            {
                deltagare.Hit();
            }
            while (deltagare.GetTotalValue() < 17);
        }
    }
}
