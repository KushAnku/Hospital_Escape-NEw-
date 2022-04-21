using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    public class QuitCommand : Command
    {
        // to quit the game.
        public QuitCommand() : base()
        {
            this.name = "quit";
        }

        override
        public bool Execute(Nurse nurse)
        {
            bool answer = true;
            return answer;
        }
    }
}