using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.PlayGame();        
        }
    }
}
//Examples of SOLID discussion:
//Single Responsibility Principle: 
//    I would direct you to the game class, specifically citing the PlayADay
//    and DisplayDailyTotals methods. Play a day is where most of the meat of the game occurs but it is simply a
//    succession of smaller, more descrete methods. Citing one of those methods, the DisplayDailyTotals is a good example
//    as it has one job to do, namely display money and inventory. I even call it a couple times to facilitate game play.
//    as those numbers change before and after purchasing, etc.
//Open/Closed Principle
//    in the weather class constructor, one could simply us weatherConditions.Add("") to creat additional  
//    weather conditions. The CreateWeatherCondition will accomodate that by extending the range automatically (line 34) to include
//    additional weather types in the list. Even if a dev forgot to create a "conditionFactor" for a new weather type,
//    it will automatically just assign a neutral value of 0 and thusly will allow the program to continue running
//    without error. This could easily be added down the road.





