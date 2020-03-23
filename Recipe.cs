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
            Console.WriteLine("Set price for a cup of lemonade");
            double userInput = Convert.ToDouble(Console.ReadLine());
            if (userInput > 0 && userInput <= 1)
            {
                pricePerCup = userInput;
            }
            else if (userInput <= 0)
            {
                Console.WriteLine("Are you mad? you gotta charge SOMETHING");
                SetPricePerCup();
            }
            else if (userInput > 1)
            {
                Console.WriteLine("No way anyone's paying that much for a cup of lemonade");
                SetPricePerCup();
            }
            else
            {
                Console.WriteLine("Please enter an appropriate price per cup");
                SetPricePerCup();
            }
        }
        public void SetLemonsPerPitcher()
        {
            Console.WriteLine("Set number of lemons per pitcher of lemonade");
            int userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput >= 1)
            {
                amountOfLemons = userInput;
            }            
            else
            {
                Console.WriteLine("Please enter an appropriate number of lemons");
                SetLemonsPerPitcher();
            }
        }
        public void SetSugarPerPitcher()
        {
            Console.WriteLine("Set number of sugar cubes per pitcher of lemonade");
            int userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput >= 1)
            {
                amountOfSugarCubes = userInput;
            }
            else
            {
                Console.WriteLine("Please enter an appropriate number of sugar cubes");
                SetSugarPerPitcher();
            }
        }
        public void SetIcePerCup()
        {
            Console.WriteLine("Set number of ice cubes per cup of lemonade");
            int userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput >= 1)
            {
                amountOfIceCubes = userInput;
            }
            else
            {
                Console.WriteLine("Please enter an appropriate number of ice cubes");
                SetIcePerCup();
            }
        }
    }
}
