using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{
    internal class DetermineWinner
    {
        public enum Winner // Metod för att anta fördefinierade värden för vinnaren av spelet
        {
            player, 
            dealer 
        }
        public Winner Result() // Metod för att bestämma vinnaren av spelet
        {
            Player player = new Player();
            Dealer dealer = new Dealer();

            int playerScore = player.Score();
            int dealerScore = dealer.Score();

            if (playerScore > 21) return Winner.dealer;   // player busts
            if (dealerScore > 21) return Winner.player;   // dealer busts
            if (playerScore > dealerScore) return Winner.player;

            return Winner.dealer;
        }
    }
}


