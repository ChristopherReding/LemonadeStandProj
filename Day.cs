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
        public List<Customer> payingCustomers;
        

        //constructor
        public Day()
        {
            this.weather = new Weather();
            customers = new List<Customer>();            
            payingCustomers = new List<Customer>();
            CreateCustomersForThatDay();
        }
        //member methods
        public void CreateCustomersForThatDay()
        {
            for (int i = 0; i < (100 + weather.todayConditionFactor); i++)
            {
                Customer customer = new Customer();
                customers.Add(customer);
            }
            

        }
        
    }
}
