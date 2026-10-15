using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{

    internal class Hand
    {
       
        List<Card> cards = new List<Card>();
        public int CardsValue { get; set; }
        public bool IsBlackjack()
        {
            if (CardsValue ==21) // kollar om värdet på handen är 21 och om man har två kort - Alex
            {
                return CardsValue > 21;  // returnerar true om handens värde är över 21 - Alex
            }
            else
            {
                return false; // returnerar false om man inte har blackjack - Alex
            }
        }
        

        public bool IsBustPlayer()
        {
            if (CardsValue > 21) // kollar om värdet på handen är över 21 - Alex
            {
                return true; // returnerar true om man har bust - Alex
            }
            else
            {
                return false; // returnerar false om man inte har bust - Alex
            }
        }

        public bool IsBust()
        {
            if (CardsValue > 21) 
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }

       /* public void CalculateAce()
        {
            int AceCount = 0; // räknar antalet ess i handen - Alex
            int PlayerTotal = Player.GetTotalValue();
            int DealerTotal = Dealer.GetTotalValue();

            foreach (Card card in cards) 
            { 
                if (card.Rank == "a") // sätter värde på ess till 11 och ökar aceCount med 1 om man har ett ess - Alex
                {
                    total += int.Parse(card.Rank); 
                }
            }
            // justerar värdet på ess om totalen är över 21 - Alex
            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }

                AceCount--;
            }
        }*/

        public List<Card> ShowHand()
        {
            return cards;
        }

    }
}
