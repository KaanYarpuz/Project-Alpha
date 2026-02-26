namespace Project_Alpha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Game starting...");

            Player player = new Player(10, World.LocationByID(1));
            player.inventory.Add(World.Weapons[0]);


            Monster Rat_M = World.Monsters[0];


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
                    player.Move();
                }
                else if (option == 3)
                {
                    // Fight
                    Console.WriteLine($"{Rat_M.Name} has appeard");
                    while (!(Rat_M.Health ==  0) || !(player.Health == 0))
                    {
                        // monster
                        Console.WriteLine("-------------------------------");
                        Rat_M.Show_Description();
                        // player
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine($"Player health: {player.Health}");
                        // Player gets options
                        Console.WriteLine("[1]: Attack\n[2]: Flee\n[3]: view inventory/change weapon");
                        int option_f = Convert.ToInt32(Console.ReadLine()); 
                        if (option_f == 1)
                        {
                            //Attack
                            Rat_M -= player.Equiped.Damage;
                        }
                        else if (option_f == 2)
                        {
                            // Flee
                            break;
                        }
                        else if (option_f == 3)
                        {
                            // view inventory
                        }
                    }

                    // monster or player dies
                    if (Rat_M.health == 0) 
                    {
                        // monster dead
                        Console.WriteLine($"{Rat_M.Name} is defeated");
                    }
                    else
                    {
                        // player dead
                        Console.WriteLine($"Weak twink ass beta ahh, your 6 feet under");
                        Gamewin = true;
                    }
                    
                }
                else if (option == 4) {Gamewin = true;}

            }
        }
    }
}