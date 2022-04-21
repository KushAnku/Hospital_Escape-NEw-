using System.Collections;
using System.Collections.Generic;
using System;

namespace Hospital_Escape
    // implementing observer interface over here to get the updates. (mentioninng the function that we will be using in this class)
    // key - to get in the particular room.
{
    // rooms is implementing observer.
    public class Rooms : Observer
    {
        private Dictionary<string, Rooms> exit;
        private Dictionary<String, Item> items;
        // this dictionary will be storing all the exit points for the nurse to leave the room.
        private List<Patient> _patients = new List<Patient>();

        public bool isAvailable { set; get; } = true;
        // we are checking that exit or room is available or not.

        private string _tags;

        public string tag
        {
            get
            {
                return _tags;
            }
            set
            {
                _tags = value;
            }
        }
        // List -> to get the list of the patient. 
        // Dictionary - to display the items.
        internal List<Patient> patients { get => _patients; set => _patients = value; }
        public Dictionary<string, int> Items { get; set; } = new Dictionary<string, int>();
        // default constructor.
        public Rooms() : this("No Tags")
        {

        }
        // giving tags to the room.
        public Rooms(string tags)
        {
            exit = new Dictionary<string, Rooms>();
            this.tag = tags;
            foreach (string key in Game.items)
            {
                Items[key] = 0;
            }
            items = new Dictionary<string, Item>();
        }

        public void setExit(string exitName, Rooms room)
        {
            exit[exitName] = room;
        }

        public Rooms getExit(string exitName)
        {
            Rooms room = null;
            exit.TryGetValue(exitName, out room);
            if(room == null)
            {
                return null;
            }
            if(room.isAvailable == true)
            {
                return room;
            }
            else
            {
                Console.WriteLine("If you would like  to enter the Cafe, you should have more " + Game.limitedPoint + "coins." + "If you would like to enter locked room, you should have a key.");
                return null;
            }
        }
        // using get exit to displaing the exit from whichever room nurse is getting out. 
        public string getExit()
        {
            string exitNames = "Exits: ";
            Dictionary<string, Rooms>.KeyCollection keys = exit.Keys;
            foreach(string exitName in keys)
            {
                exitNames += " " + exitName;
            }
            return exitNames;
        }

        public Item getItem(String item)
        {
            Item temp;
            items.TryGetValue(item, out temp);
            if (temp != null)
            {
                items.Remove(item);
            }
            return temp;
        }

        public void placeItem(Item item)
        {
            items.Add(item.Name.ToLower(), item);
        }

        // it's description about what is going on in the particular room.
        public string description()
        {
            string str = "You are at" + this._tags + " .\n ---"+ this.getExit() + " .\n ---" + "Patients : " + this._patients.Count;
            int i = 0;

            // it's mentioning the items in the room. 
            str += ". \n --- " + "Room Items : ";
            foreach (KeyValuePair<String, Item> entry in items)
            {
                    str += "\n------------------" + entry.Value.Name+"\n ";

            }

            return str;
        }
        // if the room is available or not. 
        public void updates(string tag, bool val)
        {
            if(this.tag == tag)
            {
                this.isAvailable = val;
            }
        }
        public void AddPatient(Patient patient)
        {
            _patients.Add(patient);
        }

        public bool trySavePatient()
        {
            if (patients.Count <= 0)
            {
                return false;
            }
            else
            {
                patients.RemoveAt(0);
                return true;
            }
        }

        public void update(subject observer)
        {
            throw new NotImplementedException();
        }
    }


}