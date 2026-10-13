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
            Player.AddCard(card); //Ge till player

            return card;
        }
        public int GetPlayerScore()
        {
            return Player.Score();
        }

        public Card DealerHit()
        {
            Card card = Deck.DrawCard();
            Dealer.AddCard(card);

            return card;
        }

        public int GetDealerScore()
        {
            return Dealer.Score();
        }
        

        public void PlayerStand()
        {
            // Kör dealer-logiken
        }
    }
}
