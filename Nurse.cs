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
        public Dictionary<string, Item> items = new Dictionary<string, Item>();
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

        public int brownies;

        public Nurse (Rooms room)
        {
            currentRoom = room;
            entrance = room;
            list.Add(room);

        }

        public void giveBrownie()
        {
            brownies += 1;
        }

        // using swtich statement for items.
        public bool pickUpItem(String itemName)
        {
            Item item = currentRoom.getItem(itemName.ToLower());
            if (item != null)
            {
                items.Add(item.Name, item);
                Console.WriteLine("picked up"+ item.Name);
            }
            else
            Console.WriteLine("Could not find item " + item.Name);
            return false;

        }
        // inventory for the items.
        // branching up the items. 

        public bool checkInventory(String itemName)
        {
            Item item = null;
            items.TryGetValue(itemName, out item);
            if(item!= null)
            {
                return true;
            }
            return false;
        }

        public String getInventory()
        {
            String output = "";
            output += "max Weight: " + _maxWt + "\n";
            output += "max Volume: " + _maxVol + "\n";
            output += "current Weight: " + _currWt + "\n"; 
            output += "current Volume: " + _currVol + "\n";
            //add current weight and volume
            foreach (KeyValuePair<String, Item> entry in items)
            {
                output += entry.Key;
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
            if (/*checkInventory("Stethescope")>0   || 
                checkInventory("BP machine")>0    || 
                checkInventory("Heart machine")>0 || 
                checkInventory("Defibrilator")>0 */ true  )     
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
