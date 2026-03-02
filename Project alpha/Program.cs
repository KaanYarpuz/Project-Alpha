namespace Project_Alpha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Game starting...");

            Player player = new Player(10, World.LocationByID(1));
            player.inventory.Add(World.Weapons[0]);
            player.inventory.Add(World.Weapons[1]);
            // rusty sword equipped at start
            player.Equiped = player.inventory[0];



            Console.WriteLine("World initialized.");

            bool Gamewin = false;

            while (!Gamewin)
            {
                Console.WriteLine("Choose something batty boy: ");
                Console.WriteLine("1: See game stats");
                Console.WriteLine("2: Move");
                Console.WriteLine("3: Fight");
                Console.WriteLine("4: Quit");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                
                    Console.WriteLine($"-------------\nHealth: {player.Health}");
                    player.Show_inv();
                    Console.WriteLine($"-------------");
                }
                else if (option == 2)
                {
            
                    player.Move();
                }

                else if (option == 3) {if (player.CurrentLocation.MonsterLivingHere != null)
                
                {player.gevecht();}}

                else if (option == 4) {Gamewin = true;}

            }
        }
    }
}