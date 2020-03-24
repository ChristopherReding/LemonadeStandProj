using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Recipe
    {
        //member variables
        public int amountOfLemons; //in a pitcher
        public int amountOfSugarCubes; //in a pitcher
        public int amountOfIceCubes; //in a cup
        public double pricePerCup; 

        //constructor
        public Recipe()
        {
            pricePerCup = 0.25;
            amountOfLemons = 4;
            amountOfSugarCubes = 4;
            amountOfIceCubes = 4;

        }

        //member methods
        public void SetPricePerCup()
        {
            bool numIsValid = false;
            double userInput = 0;
            while (!numIsValid || userInput <= 0 || userInput > 1)
            {
                Console.WriteLine("Set price for a cup of lemonade");
                numIsValid = Double.TryParse(Console.ReadLine(), out userInput);
            }
            pricePerCup = userInput;            
        }

        public void SetLemonsPerPitcher()
        {
            bool numIsValid = false;
            int userInput = 0;
            while (!numIsValid || userInput < 2)
            {
                Console.WriteLine("Set number of lemons per pitcher of lemonade");
                numIsValid = Int32.TryParse(Console.ReadLine(), out userInput);
            }
            amountOfLemons = userInput;                       
            
        }
        public void SetSugarPerPitcher()
        {
            bool numIsValid = false;
            int userInput = 0;
            while (!numIsValid || userInput < 2)
            {
                Console.WriteLine("Set number of sugar cubes per pitcher of lemonade");
                numIsValid = Int32.TryParse(Console.ReadLine(), out userInput);
            }
            amountOfSugarCubes = userInput;                        
        }
        public void SetIcePerCup()
        {
            bool numIsValid = false;
            int userInput = 0;
            while (!numIsValid || userInput < 2)
            {
                Console.WriteLine("Set number of ice cubes per cup of lemonade");
                numIsValid = Int32.TryParse(Console.ReadLine(), out userInput);
            }
            amountOfIceCubes = userInput;                        
        }
    }
}
