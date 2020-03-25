using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        //member variables
        public string condition;
        public int temperature;
        List<string> weatherConditions;
        public int todayConditionFactor;
        Random randomNumber;

        //constructor
        public Weather()
        {
            randomNumber = new Random();
            weatherConditions = new List<string>();
            weatherConditions.Add("Sunny");
            weatherConditions.Add("Cloudy");
            weatherConditions.Add("Rainy");            
            condition = CreateWeatherCondition();            
            temperature = CreateTemp();
            todayConditionFactor = FindConditionFactor() + FindTempFactor();

        }
        //member methods
        public string CreateWeatherCondition()
        {            
            int newRandomNumber = randomNumber.Next(0, (weatherConditions.Count));
            return weatherConditions[newRandomNumber];
        }
        public int CreateTemp()
        {            
            int todaysTemp = randomNumber.Next(50,99);
            return todaysTemp;
        }
        public int FindConditionFactor()
        {
            if (condition == "Sunny")
            {
                return 10;
            }
            else if (condition == "Rainy")
            {
                return -10;
            }
            else
            {
                return 0;
            }
        }
        public int FindTempFactor()
        {
            if (50 <= temperature && temperature <= 59)
            {
                return -10;
            }
            else if (60 <= temperature && temperature <= 69)
            {
                return -5;
            }
            else if (70 <= temperature && temperature <= 79)
            {
                return 0;
            }
            else if (80 <= temperature && temperature <= 89)
            {
                return 5;
            }
            else if (90 <= temperature && temperature <= 99)
            {
                return 10;
            }
            return 0;
        }

    }
}
