using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        //member variable
        Player player;
        List<Day> days;
        int currentDay;

        //constructor
        public Game()
        {
                
        }
        //member methods
        public void PlayGame()
        {

        }
        public void PlayADay()
        {
            //display opening of day, current money, day of the week
            //generate weather and display it
            //RECIPE: set recipe of pitcher (lemons and sugar), set number of ice cubes in cut, set price of cup
            //PURCHASING: 
                //display current inventory
                //buy items subtracting from money and adding to inventory
            //Simulation:
                //run an amount of customers past the lemonade stand (that # based on weather). for loop might be nice
                //bool whether each customer buys a cup or not (factors include weather, price)
                    //will need to define a handful of different styles of customers (ie stingy, generous, etc)
                //every 10 lemonades, make a pitcher provided ample supplies
            //Display results of day (money made, cups sold, customers seen)
        }
    }
}
