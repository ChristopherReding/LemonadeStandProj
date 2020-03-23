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
            this.weather = new Weather();
            customers = new List<Customer>();
            DetermineNumberOfCustomersThatDay();
            
        }
        //member methods
        public void DetermineNumberOfCustomersThatDay()
        {
            for (int i = 0; i < (100 + weather.todayConditionFactor); i++)
            {
                Customer customer = new Customer();
                customers.Add(customer);
            }
            

        }
        
    }
}
