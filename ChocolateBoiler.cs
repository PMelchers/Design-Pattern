using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class ChocolateBoiler
    {
        // volatile makes sure a thread never sees a reference to a partially constructed boiler
        private static volatile ChocolateBoiler? uniqueInstance;
        private static readonly object instanceLock = new object();

        // Protects empty and boiled, so the check-then-act logic in fill, drain and boil is atomic
        private readonly object stateLock = new object();

        private bool empty;
        private bool boiled;

        public bool IsEmpty { get { lock (stateLock) { return this.empty; } } }
        public bool IsBoiled { get { lock (stateLock) { return this.boiled; } } }

        // The constructor is private, so the only way to get the boiler is through GetInstance()
        // This code is only started when the boiler is empty
        private ChocolateBoiler()
        {
            empty = true;
            boiled = false;
        }
        // Double-checked locking: the first check skips the lock once the instance exists,
        // the second check (inside the lock) makes sure only one thread creates it
        public static ChocolateBoiler GetInstance()
        {
            if (uniqueInstance == null)
            {
                lock (instanceLock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new ChocolateBoiler();
                    }
                }
            }
            return uniqueInstance;
        }
        // To fill the boiler it must be empty and once it is full, we set the empty and boiled flag
        public void fill()
        {
            lock (stateLock)
            {
                if(empty)
                {
                    empty = false;
                    boiled = false;
                }
            }
        }
        // To drain the boiler, it must be full (non empty) and also boiled.
        // Once it is drained we set empty back to true
        public void drain()
        {
            lock (stateLock)
            {
                if(!empty && boiled)
                {
                    empty = true;
                }
            }
        }
        // To boil the mixture, the boiler has to be full and not already boiled.
        // Once it is boiled we set the boiled flag to true
        public void boil()
        {
            lock (stateLock)
            {
                if(!empty && !boiled)
                {
                    boiled = true;
                }
            }
        }
    }
}
