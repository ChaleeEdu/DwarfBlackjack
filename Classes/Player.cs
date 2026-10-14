using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfBlackjack.Classes
{
    internal class Player : Deltagare
    {
        Deltagare player = new Deltagare();
        

        public void PlayerTurn()
        {
            int LocalTotalValue = Player.GetTotalValue();
            if (LocalTotalValue < 21)
            
            {
                int playerinput = 0; // får värde av frontend klicka knapp för hit eller stand - Alex
                switch (playerinput) 
                {
                    case 1: 
                        Hit();
                        break;
                    case 2:
                        Stand();
                        break;
                }

            }
            else if (LocalTotalValue >= 21 || Stand==true)  // beror på hur jag hanterar stand - Alex
            {
                continue;
            }
        }
       
    }

}

