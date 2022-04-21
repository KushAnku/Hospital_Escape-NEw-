using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    class TakeCommand : Command
    {
        public TakeCommand() : base()
        {
            this.name = "take";
        }

        public override bool Execute(Nurse nurse)
        {
            this.SecondWord = this.SecondWord.ToLower();

            if (this.hasSecondWord() && this.SecondWord == "browniepoints")
            {

                bool isPicked = nurse.pickUpItem(new Item("brownie points",0,0));
                if (!isPicked)
                {
                    nurse.outputMessage("there is no such item in the current room");
                }
                else
                {
                    nurse.outputMessage("Picked up a brownie points");
                }

            }
            //  return nurse.pickUpItem("Brownie points");

            else if (this.hasSecondWord() && this.SecondWord == "bpmachine")
            {

                bool isPicked = nurse.pickUpItem(new Item("BP machine", 2,2));
                if (!isPicked)
                {
                    nurse.outputMessage("there is no such item in the current room");
                }
                else
                {
                    nurse.outputMessage("Picked up a bpmachine");
                }

            }


            //   return nurse.pickUpItem("BP machine");



            else if (this.hasSecondWord() && this.SecondWord == "heartmachine")
            {

                bool isPicked = nurse.pickUpItem(new Item("Heart machine",4,5));
                if (!isPicked)
                {
                    nurse.outputMessage("there is no such item in the current room");
                }
                else
                {
                    nurse.outputMessage("Picked up a heartmachine");
                }

            }
            // return nurse.pickUpItem("heart machine");


            else if (this.hasSecondWord() && this.SecondWord == "stethescope")
            {
                
                bool isPicked = nurse.pickUpItem(new Item("Stethescope",1,1));
                if (!isPicked)
                {
                    nurse.outputMessage("there is no such item in the current room");
                }
                else
                {
                    nurse.outputMessage("Picked up a stethescope"); 
                }

            }
            else if (this.hasSecondWord() && this.SecondWord == "defibrilator")
            {
                bool isPicked = nurse.pickUpItem(new Item("defibrilator", 1,3));
                if (!isPicked)
                {
                    nurse.outputMessage("there is no such item in the current room");
                }
                else
                {
                    nurse.outputMessage("Picked up a defibrilator");
                }

            }
            //return nurse.pickUpItem("Brownie points");
            else if (this.hasSecondWord() && this.SecondWord == "clipboard")
            {
                bool isPicked = nurse.pickUpItem(new Item("ClipBoard", 1, 3));
                if (!isPicked)
                {
                    nurse.outputMessage("there is no such item in the current room");
                }
                else
                {
                    nurse.outputMessage("Picked up a clipboard");
                }

            }
            else
            {
                nurse.outputMessage("What do you want to take?");
            }
            return false;
        }
        
       
    }
}


