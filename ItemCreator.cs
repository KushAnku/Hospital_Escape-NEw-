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
            switch(item){
                case "Heart machine":
                    return new Item(item, 4f, 5f);     // f = float
                case "Bp machine":
                    return new Item(item, 2f, 2f);
                case "Stethescope":
                    return new Item(item, 1f, 1f);
                case "Defibrillator":
                    return new Item(item, 2f, 2f);
                case "Clipboard":
                    return new Item(item, 1f, 3f);
                default:
                    return null;
            }
        }
    }
}
