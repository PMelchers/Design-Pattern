namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Let many threads ask for the boiler at the same time
            const int threadCount = 20;
            ChocolateBoiler[] boilers = new ChocolateBoiler[threadCount];
            Thread[] threads = new Thread[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                int index = i;
                threads[i] = new Thread(() => boilers[index] = ChocolateBoiler.GetInstance());
            }
            foreach (Thread thread in threads) thread.Start();
            foreach (Thread thread in threads) thread.Join();

            bool allSame = boilers.All(boiler => ReferenceEquals(boiler, boilers[0]));
            Console.WriteLine("All " + threadCount + " threads got the same boiler: " + allSame);

            // Use the boiler
            ChocolateBoiler chocolateBoiler = ChocolateBoiler.GetInstance();
            PrintState("Start", chocolateBoiler);

            chocolateBoiler.fill();
            PrintState("After fill", chocolateBoiler);

            chocolateBoiler.boil();
            PrintState("After boil", chocolateBoiler);

            chocolateBoiler.drain();
            PrintState("After drain", chocolateBoiler);

            // Same boiler again: calling GetInstance() never creates a new one
            Console.WriteLine("Same instance again: " + ReferenceEquals(chocolateBoiler, ChocolateBoiler.GetInstance()));
        }

        static void PrintState(string moment, ChocolateBoiler boiler)
        {
            Console.WriteLine(moment + " - empty: " + boiler.IsEmpty + ", boiled: " + boiler.IsBoiled);
        }
    }
}
