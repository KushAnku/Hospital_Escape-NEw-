using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    class TakeHeartMachine : takeItems
    {
        private  Nurse nurse;

        public TakeHeartMachine(Nurse nurse)
        {
            this.nurse = nurse;
        }

        public bool buyItem()
        {
            throw new NotImplementedException();
        }

        public bool take()
    {
        nurse.items["HeartMachine"] += nurse.currentRoom.Items["HeartMachine"];
        nurse.currentRoom.Items["HeartMachine"] = 0;
        if (nurse.items["HeartMachine"] >= Game.limitedPoint)
        {
            nurse.outputMessage(" \n You can enter the cafe.");
            nurse.tag_ob = "cafe";
            nurse.val_ob = true;
            nurse.notifyObservers();
        }
        nurse.outputMessage("\n" + nurse.currentRoom.description() + nurse.printNurseProperties());

        return false;
    }
    }
}