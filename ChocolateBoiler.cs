namespace Singleton
{
    internal class ChocolateBoiler
    {
        private static volatile ChocolateBoiler? instance;
        private static readonly object instanceLock = new object();

        private readonly object stateLock = new object();

        private bool empty;
        private bool boiled;

        public bool IsEmpty { get { lock (stateLock) { return this.empty; } } }
        public bool IsBoiled { get { lock (stateLock) { return this.boiled; } } }

        // This code is only started when the boiler is empty
        private ChocolateBoiler()
        {
            empty = true;
            boiled = false;
        }

        public static ChocolateBoiler GetInstance()
        {
            if (instance == null)
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ChocolateBoiler();
                    }
                }
            }
            return instance!;
        }

        // To fill the boiler it must be empty and once it is full, we set the empty and boiled flag
        public void fill()
        {
            lock (stateLock)
            {
                if (empty)
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
                if (!empty && boiled)
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
                if (!empty && !boiled)
                {
                    boiled = true;
                }
            }
        }
    }
}
