
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

            return card.ImageSource; // returnerar bildkällan för det dragna kortet
        }

        public int GetDealerScore()
        {
            return Dealer.Score();
        }

        public bool DealerNeedsCard()
        {
            return Dealer.Score() < 17; // kollar om dealern behöver ett kort (om poängen är mindre än 17)
        }
        public bool CheckBlackjack()
        {
            return Player.IsBlackjack() || Dealer.IsBlackjack(); // kollar om någon av spelarna har blackjack
        }

        public void StartRound() // Metod för att starta en ny runda nollar händerna och återställer kortleken
        {
            Deck.ResetDeck();
            Player.ResetHand();
            Dealer.ResetHand();
        }
        


        public enum Winner // Metod för att anta fördefinierade värden för vinnaren av spelet
        {
            player,
            dealer
        }
        public Winner Result() // Metod för att bestämma vinnaren av spelet
        {
            if (Dealer.IsBust()) return Winner.player;   // dealer bust returnerar player som vinnare
            else if (Player.IsBust()) return Winner.dealer; // player bust returnerar dealer som vinnare
            else if(Player.Score() > Dealer.Score()) return Winner.player;
            else if (Player.Score() < Dealer.Score()) return Winner.dealer;
            else return Winner.dealer;  // om oavgjort vinner dealer
        }
    
    }
}
