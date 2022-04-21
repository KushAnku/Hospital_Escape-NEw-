using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    // this class will carry the amount of the weight, price of the brownie points and volume of the machines that nurse will carry.
    public class Item
    {
        private string _name;
        private float _price;       // using float because it can store more vlaue than a certain value.
        private float _weight;
        private float _volume;

        public float Volume { get { return _volume; } set { _volume = value; } }

        public float Weight { get { return _weight; } set { _weight = value; } }
        //  create name 
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public float Price { get { return _price; } set { _price = value; } }
        public Item(String name, float weight, float vol)
        {
            Name = name;
            Weight = weight;
            Volume = vol;
        }
    }
}
