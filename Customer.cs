using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        //member variables
        
        public int frugalityFactor;
        Random randomNumber;

        //constructor
        public Customer()
        {
            randomNumber = new Random();
            frugalityFactor = randomNumber.Next(-5, 6);            
        }
        //member methods
        

        
    }
}
