using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    // this class basically have buy Lunch where nurse who is user can buy lunch.
    // referencing the buy command from command class which is an interface.
    // implements the Command
    class buyCommand : Command 
    {
        // just giving a name to base command.
        public buyCommand() : base()
        {
            this.name = "buy";
        }
        // tag is used for all the room (identify the rooms)
        // current room - if nurse wants to buy in any other room the command won't work it can only work for cafe.
        // using if and else statements to cafe like if there will not be cafe so nurse won't be able to buy anything.
        public override bool Execute(Nurse nurse)
        {
            if (nurse.currentRoom.tag == "Cafe")
            {
                if (this.hasSecondWord() && this.SecondWord == "( Lunch ( Soda, desert ) ")
                {
                    // to take the item.
                    //nurse.k_takeItem = new TakeLunch(nurse);
                    bool result = nurse.buyItem();
                }
                else
                {
                    nurse.outputMessage(" What would you like to buy for your Lunch? ");
                }
            }
            else
            {
                nurse.outputMessage(" You can only buy items in Cafe. ");
            }
            return false;
        }
    }
}

