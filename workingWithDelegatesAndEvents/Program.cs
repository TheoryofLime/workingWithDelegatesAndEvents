using System;

namespace delegatesAndEvents
{
    // create a delegate
    public delegate void newDelegate(int n);
    public class Race
    {
        // create a delegate event object
        public event newDelegate newDelegateEvent;

        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] participants = new int[contestants];
            bool done = false;
            int champ = -1;
            // first to finish specified number of laps wins
            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {

                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champ = i;
                        done = true;
                        continue;
                    }
                }

            }

            TheWinner(champ);
        }
        private void TheWinner(int champ)
        {
            Console.WriteLine("We have a winner!");
            // invoke the delegate event object and pass champ to the method
            newDelegateEvent(champ);
        }
    }
    class Program
    {
        public static void Main()
        {
            // create a class object
            Race round1 = new Race();
            // register with the footRace event
            round1.newDelegateEvent += footRace;
            // trigger the event
            round1.Racing(5,10);
            // register with the carRace event
            round1.newDelegateEvent -= footRace;
            round1.newDelegateEvent += carRace;
            //trigger the event
            round1.Racing(5, 10);
            // register a bike race event using a lambda expression
            round1.newDelegateEvent -= carRace;
            round1.newDelegateEvent += (champ) => Console.WriteLine($"The bike race champion is {champ}!");
            // trigger the event
            round1.Racing(5, 10);
        }

        // event handlers
        public static void carRace(int winner)
        {
            Console.WriteLine($"Car number {winner} is the winner.");
        }
        public static void footRace(int winner)
        {
            Console.WriteLine($"Racer number {winner} is the winner.");
        }
    }
}
