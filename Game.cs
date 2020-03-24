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
        Store store;
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
            this.player = new Player();
            this.store = new Store();
            Console.WriteLine("Welcome to Lemonade Stand!");
            int lengthOfGame = DetermineLengthOfGame();
            for (int i = 0; i < lengthOfGame; i++)
            {
                PlayADay(player);
            }

            
        }
        public void PlayADay(Player player)
        {            
            Day today = new Day();        //instatiate new day, generates weather
            currentDay++;                 //update number of day
            DisplayWeather(today.weather);//display weather
            DisplayDailyTotals(player);   //display starting day money and inventory
            DisplayRecipe(player);        //display yesterdays recipe
            SetRecipe(player);            //RECIPE: set recipe of pitcher (lemons and sugar), set number of ice cubes in cut, set price of cup, will display updated recipe if chosen to do so
            PurchaseInventory(player);    //PURCHASING://buy items subtracting from money and adding to inventory
            DisplayDailyTotals(player);   //updated inventory and cash before business day starts
            int likelihoodToBuyFactor = FindLikelihoodToBuyFactor(player, today);
            while (player.inventory.cups.Count >= 1 && player.inventory.iceCubes.Count >= player.recipe.amountOfIceCubes)
            {
                RunDaysTransactions(player, today, likelihoodToBuyFactor);
            }//Simulation:
            //run an amount of customers past the lemonade stand (that # based on weather). for loop might be nice
            //bool whether each customer buys a cup or not (factors include weather, price)                    
            //every 10 lemonades, make a pitcher provided ample supplies
            DisplayEndOfDaySummary(player, today);//Display results of day (cups sold, customers seen)
            
            
            
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
            Console.WriteLine($"{player.name} has: \n${player.wallet.Money} \n{player.inventory.lemons.Count} lemons" +
                $"\n{player.inventory.sugarCubes.Count} sugar cubes \n{player.inventory.iceCubes.Count} ice cubes " +
                $"\n{player.inventory.cups.Count} paper cups\n");
        }
        public void DisplayEndOfDaySummary(Player player, Day today)
        {
            Console.WriteLine($"End of day {days.Count} summary: \n{player.name} sold {today.payingCustomers.Count} " +
                $"cups of lemonade to a potential {today.customers.Count}\n");
                
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
            }
        }
        public void DisplayRecipe(Player player)
        {
            Console.WriteLine($"Your current recipe is: \n${player.recipe.pricePerCup} per cup \n{player.recipe.amountOfLemons} lemons per pitcher " +
                $"\n{player.recipe.amountOfSugarCubes} sugar cubes per pitcher \n{player.recipe.amountOfIceCubes} per cup\n");
        }
        public void PurchaseInventory(Player player)
        {
            store.SellCups(player);
            store.SellLemons(player);
            store.SellSugarCubes(player);
            store.SellIceCubes(player);
        }

        public int FindPriceFactor(Recipe recipe)
        {
            if (recipe.pricePerCup <= 0.05)
            {
                return 20;
            }
            else if (recipe.pricePerCup <= .1)
            {
                return 15;
            }
            else if (recipe.pricePerCup <= .15)
            {
                return 10;
            }
            else if (recipe.pricePerCup <= .20)
            {
                return 5;
            }
            else if (recipe.pricePerCup <= .25)
            {
                return 0;
            }
            else if (recipe.pricePerCup <= .30)
            {
                return -5;
            }
            else if (recipe.pricePerCup <= .35)
            {
                return -10;
            }
            else if (recipe.pricePerCup <= .40)
            {
                return -15;
            }
            else if (recipe.pricePerCup <= .45)
            {
                return -20;
            }
            else
            {
                return -25;
            }
        }
        public int FindLikelihoodToBuyFactor(Player player, Day today)
        {
            int priceFactor = FindPriceFactor(player.recipe);
            return (priceFactor + today.weather.todayConditionFactor);
        }
        public bool BuyLemonade(int likelihoodToBuyFactor)
        {
            Random randomNumber = new Random();
            int newRndmNum = randomNumber.Next(1, 100);
            if (newRndmNum < 50 + likelihoodToBuyFactor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void RunDaysTransactions(Player player, Day today, int likelihoodToBuyFactor)
        {
            for (int i = 0; i < today.customers.Count; i++)
            {
                player.pitcher.MakeNewPitcher(player);
                if (BuyLemonade(likelihoodToBuyFactor) == true && player.pitcher.cupsLeftinPitcher > 0)
                {
                    Customer payingCustomer = new Customer();
                    today.payingCustomers.Add(payingCustomer);
                    player.inventory.RemoveCupsFromInventory(1);
                    player.inventory.RemoveIceCubesFromInventory(player.recipe.amountOfIceCubes);
                    player.wallet.TakePaymentForLemonade(player.recipe.pricePerCup);
                    player.pitcher.cupsLeftinPitcher--;
                }
            }
        }
        public int DetermineLengthOfGame()
        {
            bool numIsValid = false;
            int daysToPlay = 0;
            while (!numIsValid || daysToPlay < 7 || daysToPlay > 30)
            {
                Console.WriteLine("How many days would you like to play? (enter a number from 7 to 30)");
                numIsValid = Int32.TryParse(Console.ReadLine(), out daysToPlay);            
                 
            }
            return daysToPlay;
            
        }
    }
}
