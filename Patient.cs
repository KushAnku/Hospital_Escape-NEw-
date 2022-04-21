using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    // we are generating random patient in the room.
    public class Patient
    {
        Random random = new Random();
        public Dictionary<string, int> Items { get; set; } = new Dictionary<string, int>();
        // Generic type where it store items.

        public Patient()
        {
            foreach(string key in Game.items)
            {
                Items[key] = 0;
            }

            for(int i=0; i<= random.Next(0,7); i++)
            {
                string myName = Game.items[0];
                Items[myName] += 1;
            }

            List<string> deskItems = new List<string>()
            {
                "stethescope", "HeartMachine", "BpMachine", "Clipboard"
            };
            //Items[deskItems[random.Next(5)]] = 1;
        }
    }
}
