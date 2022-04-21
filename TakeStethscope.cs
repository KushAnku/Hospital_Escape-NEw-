using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    class takestethoscope : takeItems
    {
        private Nurse nurse;

        public takestethoscope(Nurse nurse)
        {
            this.nurse = nurse;
        }

        public bool buyItem()
        {
            throw new NotImplementedException();
        }

        public bool take()
        {
            nurse.items["stethoscope"] += nurse.currentRoom.Items["stethoscope"];
            nurse.currentRoom.Items["stetescope"] = 0;
            if(nurse.items["stethoscope"] >= Game.limitedPoint)
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
