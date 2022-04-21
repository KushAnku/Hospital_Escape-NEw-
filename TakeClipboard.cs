using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    class TakeClipboard : takeItems
    {
        private Nurse nurse;

        public TakeClipboard (Nurse nurse)
            
        {
            this.nurse = nurse;
        }

        public bool buyItem()
        {
            throw new NotImplementedException();
        }

        public bool take()
    {
        nurse.items["Clipboard"] += nurse.currentRoom.Items["Clipboard"];
        nurse.currentRoom.Items["ClipBoard"] = 0;
        if (nurse.items["Clipboard"] >= Game.limitedPoint)
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