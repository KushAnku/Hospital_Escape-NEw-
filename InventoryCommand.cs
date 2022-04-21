using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    // implements the interface Command
    class InventoryCommand : Command
    {
        public InventoryCommand() : base()
        {
            this.name = "inventory";            
        }
public override bool Execute(Nurse nurse)
        {
            nurse.outputMessage(nurse.getInventory());
            return false;
        }
    }
}
