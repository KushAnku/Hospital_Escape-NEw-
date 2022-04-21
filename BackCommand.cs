using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    // using back command the user can go back.
    // implements the  Command
    class backcommand : Command
    {
        // When generating instance of the derived class, 
        // specify which base-class constructor is being used.
        public backcommand() : base()
        {
            this.name = "back";
        }
       // user wants to go back or not that is where we can use execute. ( giving you a message) .
       // nurse class excuting the object called nurse.

        public override bool Execute(Nurse nurse)
        {
            if (this.hasSecondWord())
            {
                nurse.outputMessage("\n If you want to go back ! Please type 'back' ");
            }
            else
            {
                bool result = nurse.goBack();
            }
            return false;
        }
    }
}