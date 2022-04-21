using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    class SaveCommand : Command
    {
        public SaveCommand() : base()
        {
            this.name = "save";
        }

        override
            public bool Execute(Nurse nurse)
        {
            if (this.hasSecondWord() &&
                this.SecondWord == "Patient")
            {
                bool result = nurse.save();
            }
            else
            {
                nurse.outputMessage("\n If you want to save the patient ? Please use the ' save Patient' Command");
            }
            return false;
        }
    }
}