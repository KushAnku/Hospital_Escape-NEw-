using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    // nurse class - what are the things nurse will have or what nurse has to do, 
    // the branches that the nurse has to deal through the game.
    // using dictionary beacuse it's type of collection that is used to hold key/value pairs.
    public class Nurse : subject
    {
        public Dictionary<string, int> items = new Dictionary<string, int>();
        private List<Rooms> list = new List<Rooms>();
        private List<Rooms> observers = new List<Rooms>();
    
        private float _maxVol=0.0F, _maxWt=10.0F, _currVol, _currWt;

        //do this for all the private variables we added
        public float CurrVol { get { return _currVol; } set { _currVol += value; } }
        public float CurrWt { get { return _currWt; } set { _currWt += value; } }

        public string tag_ob { set; get; }
        
        public bool val_ob { set; get; } = false;

        public takeItems k_takeItem { set; get;}

        public Rooms currentRoom { get; set; }

        private Rooms entrance;

        public Nurse (Rooms room)
        {
            currentRoom = room;
            entrance = room;
            list.Add(room);
            foreach(string key in Game.items)
            {
                items[key] = 0;
            }
        }

        public void giveBrownie()
        {
            items["Brownie points"] += 1;
        }

        // using swtich statement for items.
        public bool pickUpItem(Item item)
        {
            String itemName = item.Name;
            switch (itemName)
            {
                case "Stethescope":
                    if (currentRoom.getItem("Stethescope"))
                    {
                        items["Stethescope"] += 1;
                        return true;
                    }
                    break;
                case "BP machine":
                    if (currentRoom.getItem("BP machine"))
                    {
                        items["BP machine"] += 1;
                        return true;
                    }
                    break;
                case "Heart machine":
                    if (currentRoom.getItem("Heart machine"))
                    {
                        items["Heart machine"] += 1;
                        return true;
                    }
                    break;
                case "Brownie points":
                    if (currentRoom.getItem("Brownie points"))
                    {
                        items["Brownie points"] += 1;
                        return true;
                    }
                    break;
                case "ClipBoard":
                    if (currentRoom.getItem("ClipBoard"))
                    {
                        items["Clipboard"] += 1;
                        return true;
                    }
                    break;
                case "defibrilator":
                    if (currentRoom.getItem("Defibrilator"))
                    {
                        items["Defibrilator"] += 1;
                        return true;
                    }
                    break;
            }
            return false;

        }
        // inventory for the items.
        // branching up the items. 

        public int checkInventory(String item)
        { 
            switch (item)
            {
                case "Stethescope":
                    return items["Stethescope"];
                    break;
                case "BP machine":
                    return items["BP machine"];
                    break;
                case "Heart machine":
                    return items["Heart machine"];
                    break;
                case "Brownie points":
                    return items["Brownie points"];
                    break;
                case "Clipboard":
                    return items["Clipboard"];
                    break;
                case "Defibrilator":
                    return items["Defibrilator"];
                    break;
                default:
                    return -1;
            }
        }

        public String getInventory()
        {
            String output = "";
            output += "max Weight: " + _maxWt + "\n";
            output += "max Volume: " + _maxVol + "\n";
            output += "current Weight: " + _currWt + "\n";
            output += "current Volume: " + _currVol + "\n";
            //add current weight and volume
            foreach (KeyValuePair<String, int> entry in items)
            {
                output += entry.Key + ": " + entry.Value.ToString() + "\n";
            }
            return output;
        }
        // to make nurse move from one room to another.
        public bool WalkTo(string direction)
        {
            Rooms nextRoom = this.currentRoom.getExit(direction);

            if(nextRoom != null)
            {
                if(nextRoom.tag == " escape zone ")
                {
                    Random random = new Random();
                    nextRoom = Game.rooms[random.Next(11)];

                }
                this.currentRoom = nextRoom;
                this.list.Add(nextRoom);
                this.outputMessage("\n" + this.currentRoom.description());
            }

            else
            {
                this.outputMessage(" There is no door on " + direction);
            }

            return false;
        }

        public bool goBack()
        {
            int lastIndex = this.list.Count - 1;
            if (lastIndex >= 1)
            {
                this.list.RemoveAt(lastIndex);
                this.currentRoom = this.list[lastIndex - 1];
                this.outputMessage("\n" + this.currentRoom.description());
                return false;
            }
            else
            {
                this.outputMessage("\n You cannot go back anymore. ");
                this.outputMessage("\n" + this.currentRoom.description());
                return false;
            }

        }

        // showing the items when nurse is walking or how many points nurse have.
        public string printNurseProperties()
        {
            string str = "\n\n -- Nurse: ";
            str += " Items with nurse: ";
            return str;
        }
        public bool buyItem()
        {
            return this.k_takeItem.buyItem();
        }

        public void outputMessage(string message)
        {
            Console.WriteLine(message);
        }
        // creating the save method to save the patient.
        public bool save()
        {
            if (checkInventory("Stethescope")>0   || 
                checkInventory("BP machine")>0    || 
                checkInventory("Heart machine")>0 || 
                checkInventory("Defibrilator")>0)           
            {
                bool success = this.currentRoom.trySavePatient();
                if (success)
                {
                    Console.WriteLine(" You saved a patient");
                    NotificationCenter.Instance.PostNotification(new Notification(" patient saved ", this));
                }
                else
                {
                    Console.WriteLine(" There is no patient in this room ");
                }
            }
            else
            {
                Console.WriteLine(" You don't have the right tools to save the patient ");
            }
            return false;
        }

        public void registerObserver(Rooms ob)
        {
            this.observers.Add(ob);
        }

        public void removeObserver(Rooms ob)
        {
            this.observers.Remove(ob);
        }
        // notify observers .
        public void notifyObservers()
        {
            foreach (Rooms room in observers)
            {
                room.updates(tag_ob, val_ob);
            }
        }

      

    
    }
}
