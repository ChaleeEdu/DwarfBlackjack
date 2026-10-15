using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{
    internal class BlackjackGame
    {
        public Player Player { get; }
        public Dealer Dealer { get; }
        public Deck Deck { get; }

        public BlackjackGame()
        {
            Deck = new Deck();
            Player = new Player();
            Dealer = new Dealer();
        }

        public Card PlayerHit()
        {
            Card card = Deck.DrawCard(); //Ta ett kort från deck
            Player.Hit(); //Ge till player
        }
        public int GetPlayerScore()
        {
            Player.GetTotalValue(); //Returnera spelarens poäng
        }

        public Card DealerHit()
        {
            Card card = Deck.DrawCard();
            Dealer.Hit();
        }

        public int GetDealerScore()
        {
            Dealer.GetTotalValue();
        }
        

        public void PlayerStand()
        {
            // Kör dealer-logiken - Stand svårt
        }
    }
}
