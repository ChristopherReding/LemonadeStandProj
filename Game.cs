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
            currentDay = 0;
                
        }
        //member methods
        public void PlayGame()
        {
            Player player = new Player();
        }
        public void PlayADay(Player player)
        {            
            Day today = new Day();        //instatiate new day, generates weather
            currentDay++;                 //update number of day
            DisplayWeather(today.weather);//diplayer todaysweather
            DisplayDailyTotals(player);


            

            //generate weather and display it
            //display opening of day, current money, day of the week
            //RECIPE: set recipe of pitcher (lemons and sugar), set number of ice cubes in cut, set price of cup
            //PURCHASING: 
                //display current inventory
                //buy items subtracting from money and adding to inventory
            //Simulation:
                //run an amount of customers past the lemonade stand (that # based on weather). for loop might be nice
                //bool whether each customer buys a cup or not (factors include weather, price)                    
                //every 10 lemonades, make a pitcher provided ample supplies
            //Display results of day (money made, cups sold, customers seen)
        }
        public void WelcomeToDay()
        {
            Console.WriteLine($"It is day {currentDay}. Here are your totals:");
        }
        public void DisplayWeather(Weather weather)
        {
            Console.WriteLine($"Today's weather is {weather.condition}/{weather.temperature} F");
        }
        public void DisplayDailyTotals(Player player)
        {
            Console.WriteLine($"{player.name} has: \n${player.wallet.Money} \n{player.inventory.lemons.Count} lemons " +
                $"\n);{player.inventory.sugarCubes.Count} sugar cubes \n{player.inventory.iceCubes.Count} ice cubes " +
                $"\n {player.inventory.cups.Count} paper cups");
        }
    }
}
