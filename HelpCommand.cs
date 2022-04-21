using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{ 
    // Help command is to help the lost user to find their path.
    // implements the command.
    public class HelpCommand : Command
    {
        CommandWord words;
        public HelpCommand() : base()
        {
        //words = commands;
            this.name = "help"; // setting an intitial variable name.
        }
        // The override modifier extends the base class virtual method.
        override
        public bool Execute(Nurse nurse)
        {
            nurse.outputMessage("\n You are lost. You are alone. Now you will lost in the Hospital \n " +
                                "\n Your available commands are :-");
            nurse.outputMessage("- Type 'go West' to move West side in the Hospital ");
            nurse.outputMessage("- Type 'go East' to move East side in the Hospital ");
            nurse.outputMessage("- Type 'go North' to move North side in the Hospital ");
            nurse.outputMessage("- Type 'go South' to move South side in the Hospital");
            nurse.outputMessage("- Type 'take bpmachine' to pick up the item from rooms or helpdesk"); 
            nurse.outputMessage("- Type 'take heartmachine' to pick up the item from rooms or helpdesk");
            nurse.outputMessage("- Type 'take clipboard' to pick up the item from rooms or helpdesk");
            nurse.outputMessage("- Type 'take stethescope' to pick up the item from rooms or helpdesk");
            nurse.outputMessage("- Type 'take defibrillator' to pick up the item from rooms or helpdesk");
            nurse.outputMessage("- Type 'save Patient ' to save the patient");
            nurse.outputMessage("-'Hope this information help you :-) :-) :-) :-)");
            return false; 
        }
    }
}