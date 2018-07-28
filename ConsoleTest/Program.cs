namespace ConsoleTest
{
    using System;
    using TrafficLightLib;
    using System.Timers;

    public class Program
    {
        public static void Main(string[] args)
        {
            TrafficLighter lighter = new TrafficLighter(new RedState());

            // Will be switched every two seconds
            Timer timer = new Timer
            {
                Interval = 2000,
            };

            // this event causes a change of state
            timer.Elapsed += (sender, eventArgs) =>
            {
                Console.Clear();
                lighter.Switch();
                Console.WriteLine(lighter.Color);
            };

            timer.Start();
            Console.ReadKey();      // ends when you pressed any key
            timer.Stop();
        }
    }
}
