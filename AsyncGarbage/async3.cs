using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace AsyncBreakfast
{

    class Async3
    {
        public static async Task Main(string[] args)
        {
            /* 
             * making toast is a combination of an async call to cook the toast and then sync calls to butter and jam
             * 
             * "The composition of an asynchronous operation followed by synchronous work is an asynchronous operation. 
             * Stated another way, if any portion of an operation is asynchronous, the entire operation is asynchronous."
             *  
             * what changed?
             *  - we made a new method for MakeToastWithButterAndJamAsync to allow that whole process to be asyn
             * */

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);


            Egg eggs = await eggsTask;
            Console.WriteLine("eggs are ready");
            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");
            Toast toast = await toastTask;
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");

            Console.WriteLine("Breakfast is ready!");
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int slices)
        {
            var toast = await ToastBreadAsync(slices);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");

            //await Task.Delay(2000);
            //Console.WriteLine("Fire! Toast is ruined!");
            //throw new InvalidOperationException("The toaster is on fire");

            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}