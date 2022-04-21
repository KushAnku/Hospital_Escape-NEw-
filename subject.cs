using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    public class subject 
    {
        private List<Observer> observers = new List<Observer>();
        private int state;

        public int getState()
        {
            return state;
        }

        public void setState(int state)
        {
            this.state = state;
            notifyAllObservers();
        }

        public void attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void notifyAllObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update(this);
            }
        }
        void detach(Observer ob)
        {
            observers.Remove(ob);
        }
    }
}
