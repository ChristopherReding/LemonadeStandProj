using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Pitcher
    {
        //member variables
        public int cupsLeftinPitcher;

        //constructor
        public Pitcher()
        {
            cupsLeftinPitcher = 0;
        }
        //member methods
        public void MakeNewPitcher(Player player)
        {
            if (cupsLeftinPitcher == 0 && player.recipe.amountOfLemons <= player.inventory.lemons.Count && player.recipe.amountOfSugarCubes <= player.inventory.sugarCubes.Count)
            {
                int numberOfLemons = player.recipe.amountOfLemons;
                int numberOfSugarCubes = player.recipe.amountOfSugarCubes;
                player.inventory.RemoveLemonsFromInventory(numberOfLemons);
                player.inventory.RemoveSugarCubesFromInventory(numberOfSugarCubes);
                cupsLeftinPitcher = 10;
            }
            
           
        }
    }
}
