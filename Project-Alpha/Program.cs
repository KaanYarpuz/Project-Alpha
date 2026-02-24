using System;

namespace Project_Alpha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Game starting...");

            var locations = World.Locations;

            foreach (var location in locations)
            {
                Console.WriteLine($"Location: {location.Name}");
            }



            Console.WriteLine("World initialized.");
        }
    }
}