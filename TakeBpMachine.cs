using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    // taking the bp machine
    class TakeBpMachine : takeItems
    {
        private Nurse nurse;

        public TakeBpMachine (Nurse nurse)
        {
            this.nurse = nurse;
        }
        
        public bool take()
        {
            nurse.pickUpItem(new Item("BPMachine", 2,2));
            nurse.currentRoom.Items["BPMachine"] -= 1;
            if (nurse.items["BPMachine"] >= Game.limitedPoint)
            {
                nurse.outputMessage(" \n You can enter the cafe.");
                nurse.tag_ob = "cafe";
                nurse.val_ob = true;
                nurse.notifyObservers();
            }
            nurse.outputMessage("\n" + nurse.currentRoom.description() + nurse.printNurseProperties());

            return false;
        }

        public bool buyItem()
        {
            nurse.outputMessage(" There is nothing to buy. \n");
            return false;
        }
    }
}