using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    /*Factory design pattern.
      Used to create all the items in the game  
       like stethoscope or heart machine. We can find this pattern in item creator file.*/
    class ItemCreator
    {

        public Item FactoryMethod(String item)
        {
            item = item.ToLower();
            switch(item){
                case "heart machine":
                    return new Item("HeartMachine", 4f, 5f);     // f = float
                case "bp machine":
                    return new Item("BpMachine", 2f, 2f);
                case "stethescope":
                    return new Item(item, 1f, 1f);
                case "defibrillator":
                    return new Item(item, 2f, 2f);
                case "clipboard":
                    return new Item(item, 1f, 3f);
                default:
                    Console.WriteLine(item);
                    return null;
            }
        }
    }
}
