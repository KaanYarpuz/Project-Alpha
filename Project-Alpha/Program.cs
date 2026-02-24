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

            bool Gamewin = false;
            int option = 0;

            while (!Gamewin)
            {
                Console.WriteLine("Choose something batty boy: ");
                Console.WriteLine("1: See game stats");
                Console.WriteLine("2: Move");
                Console.WriteLine("3: Fight");
                Console.WriteLine("4: Quit");

                option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    // Game stats
                }
                else if (option == 2)
                {
                    // Move
                }
                else if (option == 3)
                {
                    // Fight
                }
                else if (option == 4) {Gamewin = true;}

            }
        }
    }
}