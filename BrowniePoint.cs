using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    // Initializing the brownie point and making this class available to use when neccessary.
    //( like whenever we need brownie points ).

    // implements the Item.
    class BrowniePoint : Item
    {
    // base - reference 
    // brownie point is an integer.


        public BrowniePoint(int value): base("brownie",0,0)
        {
            Name = "brownie";
        }
    }
}
