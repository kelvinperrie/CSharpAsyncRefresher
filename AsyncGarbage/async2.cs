using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace AsyncBreakfast
{

    class Async2
    {
        public static async Task Main(string[] args)
        {
            /* what changed?
             *  - we changed our methods to have the async key word in the signature and changed the name
             *  - we changed our methods to return a Task<Thing> rather than just a Thing. e.g. eggsTask now holds the running FryEggs
             *  - we changed the wait statements so that they weren't blocking
             *  - we store the thingTask from each of our async calls
             *  - we put awaits for our taskThings right at the end of our method - thats when we wait for them to finish
             *  - whatever calls this Main method now has to have an await, otherwise when we hit the first await below it will jump up the chain and exit the program
             * */

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = ToastBreadAsync(2);

            // when we hit this await, we give control back to whatever called this method (whatever called the Main method) until
            // the toastTask has completed.
            Toast toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");

            Egg eggs = await eggsTask;
            Console.WriteLine("eggs are ready");
            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");

            Console.WriteLine("Breakfast is ready!");
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
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