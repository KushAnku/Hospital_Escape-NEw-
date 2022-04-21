using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    // this command is used for move wherever the user wants to move.
        public class GoCommand : Command
        {
        // creating the constructor for go command.
        // When generating instance of the derived class, 
        // specify which base-class constructor is being used
        public GoCommand() : base()
            {
                this.name = "go";
            }

        override
        public bool Execute(Nurse nurse)
        {
            bool result = false;
            if (this.hasSecondWord())
            {
                result = nurse.WalkTo(this.SecondWord);
            }
            else
            {
                nurse.outputMessage("\nWhere do you want to go? ");
            }
            return result;
        }
    }
}
