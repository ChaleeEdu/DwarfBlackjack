using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{

    internal class Hand
    {
        List<Card> cards = new List<Card>();
        public int CardsValue { get; set; }

        public bool IsBust
        {
            get // hämtar värdet på handen - Alex
            {
                return CardsValue > 21;  // returnerar true om handens värde är över 21 - Alex
            }
        }
        public Hand()
        {
        }
        public void AddCard(Card card)
        {
            cards.Add(card);
            CalculateCount();
        }
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

    }
}
