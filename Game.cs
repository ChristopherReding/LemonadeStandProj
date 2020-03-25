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
        int totalDays;
        Random randomNumber;

        //constructor
        public Game()
        {
            randomNumber = new Random();
            days = new List<Day>();
        }
        //member methods
        public void PlayGame()
        {
            player = new Player();
            store = new Store();
            Console.WriteLine("Welcome to Lemonade Stand!");
            totalDays = DetermineLengthOfGame();
            for (int i = 0; i < totalDays; i++)
            {
                PlayADay(player);
            }
            Console.WriteLine($"Game Over! \nAfter {totalDays} days, you made ${player.wallet.Money} \n" +
                $"Thanks for playing!");
        }
        public void PlayADay(Player player)
        {            
            Day today = new Day();        
            days.Add(today);
            DisplayWeather(today.weather);
            DisplayDailyTotals(player);   
            DisplayRecipe(player);        
            SetRecipe(player);            
            PurchaseInventory(player);    
            DisplayDailyTotals(player);   
            int likelihoodToBuyFactor = FindLikelihoodToBuyFactor(player, today);
            RunDaysTransactions(player, today, likelihoodToBuyFactor);  
            DisplayEndOfDaySummary(player, today);
            BurnIceDaily(player);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            
        }
        
        public void DisplayWeather(Weather weather)

        {
            Console.WriteLine($"Day {days.Count}: \nToday's weather is {weather.condition}/{weather.temperature} F\n");
        }
        public void DisplayDailyTotals(Player player)
        {
            Console.WriteLine($"{player.name} has: \n${player.wallet.Money} \n{player.inventory.lemons.Count} lemons" +
                $"\n{player.inventory.sugarCubes.Count} sugar cubes \n{player.inventory.iceCubes.Count} ice cubes " +
                $"\n{player.inventory.cups.Count} paper cups\n");
        }
        public void DisplayEndOfDaySummary(Player player, Day today)
        {
            Console.WriteLine($"End of day {days.Count}/{totalDays} summary: \n{player.name} sold {today.payingCustomers.Count} " +
                $"cups of lemonade to a potential {today.customers.Count} customers\n");
                
        }
        public void SetRecipe(Player player)
        {
            Console.WriteLine("Would you like to adjust this recipe? \nEnter 1 for yes \nEnter 2 for no");
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
                Console.WriteLine("OK, let's keep it the same\n");                
            }
        }
        public void DisplayRecipe(Player player)
        {
            Console.WriteLine($"Your current recipe is: \n${player.recipe.pricePerCup} per cup \n{player.recipe.amountOfLemons} lemons per pitcher " +
                $"\n{player.recipe.amountOfSugarCubes} sugar cubes per pitcher \n{player.recipe.amountOfIceCubes} ice cubes per cup\n");
        }
        public void PurchaseInventory(Player player)
        {
            store.SellCups(player);
            store.SellLemons(player);
            store.SellSugarCubes(player);
            store.SellIceCubes(player);
            Console.WriteLine(" ");
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
                if (player.pitcher.cupsLeftinPitcher <= 0 || player.inventory.cups.Count <= 0 || 
                    player.inventory.iceCubes.Count < player.recipe.amountOfIceCubes)
                {
                    break;
                }
                else if (BuyLemonade(likelihoodToBuyFactor + today.customers[i].frugalityFactor) == true)
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
                Console.WriteLine(" "); 
            }
            return daysToPlay;
            
        }
        public void BurnIceDaily(Player player)
        {
            if (player.inventory.iceCubes.Count > 0)
            {
                Console.WriteLine("The rest of your ice has melted\n");
                player.inventory.RemoveIceCubesFromInventory(player.inventory.iceCubes.Count);
            }
        }
    }
}
