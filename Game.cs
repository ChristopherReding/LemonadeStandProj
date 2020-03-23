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
        int totalDays;

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
            DisplayWeather(today.weather);//display weather
            DisplayDailyTotals(player);   //display starting day money and inventory
            SetRecipe(player);            //RECIPE: set recipe of pitcher (lemons and sugar), set number of ice cubes in cut, set price of cup
            DisplayRecipe(player);

                        
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
            Console.WriteLine($"It is day {currentDay}/{totalDays}. Here are your totals:");
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
        public void SetRecipe(Player player)
        {
            Console.WriteLine("Would you like to adjust the recipe from yesterday? \nEnter 1 for yes \nEnter 2 for no");
            string adjust = Console.ReadLine();
            if(adjust == "1")
            {
                player.recipe.SetPricePerCup();
                player.recipe.SetLemonsPerPitcher();
                player.recipe.SetSugarPerPitcher();
                player.recipe.SetIcePerCup();
                DisplayRecipe(player);
            }
            else
            {
                Console.WriteLine("OK, let's keep it the same");
                DisplayRecipe(player);
            }
        }
        public void DisplayRecipe(Player player)
        {
            Console.WriteLine($"Your current recipe is: \n${player.recipe.pricePerCup} per cup \n{player.recipe.amountOfLemons} lemons per pitcher " +
                $"\n{player.recipe.amountOfSugarCubes} sugar cubes per pitcher \n{player.recipe.amountOfIceCubes} per cup"));
        }
    }
}
