using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{
    internal class BlackjackGame
    {
        Deck deck = new Deck();
        Dealer dealer = new Dealer();
        Player player = new Player();

        public BlackjackGame()
        {

        }

        public void StartGame()
        {
            
        }
        public int GetPlayerValue()
        {
            return 0;
        }
        
        /*
         * Logik för att gömma värdet på andra kortet
         */
        public int GetDealerValue()
        {
            return 0;

        }
    }
}
