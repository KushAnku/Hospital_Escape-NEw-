using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    class TakeLunch : takeItems

    {
        private Nurse nurse;
        public TakeLunch(Nurse nurse)
        {
            this.nurse = nurse;
        }

        public bool buyItem()
        {
            throw new NotImplementedException();
        }
        public bool take()
        {
            nurse.pickUpItem(new Item("Brownie point",0,0));
            nurse.currentRoom.Items["brownie"] = 0;
            if (nurse.checkInventory("Brownie point")>= Game.limitedPoint)
            {
                nurse.outputMessage("\n You can enter the Cafe.");
                nurse.tag_ob = "cafe";
                nurse.val_ob = true;
                nurse.notifyObservers();
            }
            nurse.outputMessage("\n" + nurse.currentRoom.description() + nurse.printNurseProperties());

            return false;
        }
    }
}
