namespace Project_Alpha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Game starting...");

            Player player = new Player(10);
            player.inventory.Add(World.Weapons[0]);

            var locations = World.Locations;

            Monster Rat_M = World.Monsters[0];

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
                    Console.WriteLine($"-------------\nHealth: {player.Health}");
                    player.Show_inv();
                    Console.WriteLine($"-------------");
                }
                else if (option == 2)
                {
                    // Move
                }
                else if (option == 3)
                {
                    // Fight
                    Rat_M.Show_Description();
                    while (Rat_M.Health ==  0 || player.Health == 0)
                    {
                        
                    }
                    
                }
                else if (option == 4) {Gamewin = true;}

            }
        }
    }
}