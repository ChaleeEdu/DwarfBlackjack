


namespace DwarfBlackjack.Classes
{
    //Kontrollern för backend
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
        //Drar ett kort från Deck och ger till Dealer och returnerar ImageSource till frontend
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
        public bool CheckPlayerBlackjack()
        {
            return Player.IsBlackjack();
        }
        public bool CheckDealerBlackjack()
        {
            return Dealer.IsBlackjack();
        }

        public bool IsPlayerBust()
        {
            return Player.IsBust();
        }

        public bool PlayerHas21()
        {
            return Player.Has21();
        }

        public void StartRound()
        {
            Deck.ResetDeck();
            Player.ResetHand();
            Dealer.ResetHand();
        }



        public enum Winner // Metod för att anta fördefinierade värden för vinnaren av spelet
        {
            Player,
            Dealer
        }
        public Winner State { get; private set; }
        public void Result() // Metod för att bestämma vinnaren av spelet
        {

            //if (playerScore > 21) return Winner.dealer;   // player bust
            if (Dealer.IsBust()) State = Winner.Player;   // dealer bust
            else if (Player.Score() > Dealer.Score()) State = Winner.Player;
            else if (Player.Score() < Dealer.Score()) State = Winner.Dealer;
            else State = Winner.Dealer;  // om oavgjort vinner dealer
            //return Winner.dealer;
        }
        public string CheckWinner()
        {

            if (Dealer.IsBust())
                return "Player";

            if (Player.Score() > Dealer.Score())
                return "Player";

            if (Dealer.Score() > Player.Score())
                return "Dealer";

            return "Dealer";
        }

    }
}
