using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        //member variables
        public Weather weather;
        public List<Customer> customers;

        //constructor
        public Day()
        {
            Weather todaysWeather = new Weather();           

            for (int i = 0; i < (100 + todaysWeather.FindConditionFactor() + todaysWeather.FindTempFactor()); i++)
            {
                Customer customer = new Customer();
                customers.Add(customer);
            }
        }
        //member methods
        
        
    }
}
