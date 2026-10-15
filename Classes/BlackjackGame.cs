
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

        public string PlayerHit()
        {
            Card card = Deck.DrawCard(); //Ta ett kort från deck
            Player.AddCard(card); //Ge till player

            return card.ImageSource;
        }

        public int GetPlayerScore()
        {
            return Player.Score();
        }

        public string DealerHit()
        {
            Card card = Deck.DrawCard();
            Dealer.AddCard(card);

            return card.ImageSource;
        }

        public int GetDealerScore()
        {
            return Dealer.Score();
        }

        public bool DealerNeedsCard()
        {
            return Dealer.Score() < 17;
        }
        public bool CheckBlackjack()
        {
            return Player.IsBlackjack() || Dealer.IsBlackjack();
        }

        public void StartRound()
        {
            Deck.ResetDeck();
            Player.ResetHand();
            Dealer.ResetHand();
        }
        public DetermineWinner.Winner Result() // kalla den här metod för att avgöra vinnaren efter att rundan är slut - Alex
        {
            DetermineWinner determineWinner = new DetermineWinner(); 
            return determineWinner.Result();
        }
}
}
