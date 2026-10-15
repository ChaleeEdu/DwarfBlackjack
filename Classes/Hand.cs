using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{

    internal class Hand
    {
       
        List<Card> cards = new List<Card>();
        public Hand()
        {
        }
        public int CardsValue { get; set; }
        public bool IsBlackjack()
        {
            if (CardsValue ==21) // kollar om värdet på handen är 21 och om man har två kort - Alex
            {
                return true; // returnerar true om man har blackjack - Alex
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
                     PlayerTotal || DealerTotal += 11; 
                     AceCount++;
                 }           
             }
             // justerar värdet på ess om totalen är över 21 - Alex
             while ((PlayerTotal > 21 && AceCount > 0) || (DealerTotal > 21 && AceCount > 0))
             {
                 PlayerTotal || DealerTotal -= 10; // justerar värdet på ess till 1 istället för 11 - Alex

                 AceCount--;
             }

                 AceCount--;
             }
         }*/

        public void CalculateCount()
        {
            int aceCount = 0; // räknar antalet ess i handen - Alex
            int total = 0; // värde på handen, så tex om man har 2, 3 och 4 så blir värdet 9 - Alex

            foreach (Card card in cards)
            {
                if (card.Rank == "a") // sätter värde på ess till 11 och ökar aceCount med 1 om man har ett ess - Alex
                {
                    total += 11;
                    aceCount++;
                }
                else if (card.Rank == "j" || card.Rank == "q" || card.Rank == "k") // sätter värde på klädda kort till 10 - Alex
                {
                    total += 10;
                }
                else // sätter värde på resterande kort alltså 2-10 - Alex
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

            CardsValue = total; // total är en lokal variabel, skickar värdet till cardsValue så det sparas - Alex
        }

        public List<Card> ShowHand()
        {
            return cards;
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
            CalculateCount();
        }

    }
}
