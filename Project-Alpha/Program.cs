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
                    Monster? monster = player.CurrentLocation.MonsterLivingHere;

                    if (monster == null)
                    {
                        Console.WriteLine("There is no monster here to fight.");
                        continue;
                    }
                    // Fight
                    while (monster.Health >=  0 && player.Health >= 0)
                    {
                        // monster
                        Console.WriteLine("-------------------------------");
                        monster.Show_Description();
                        // player
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine($"Player health: {player.Health}");
                        // Player gets options
                        Console.WriteLine("[1]: Attack\n[2]: Flee\n[3]: view inventory/change weapon");
                        int option_f = Convert.ToInt32(Console.ReadLine()); 
                        if (option_f == 1)
                        {
                            //Attack monster
                            monster.Health -= player.Equiped.Damage;
                            Console.WriteLine($"You deal {player.Equiped.Damage}");
                            if (monster.Health >= 1)
                            {
                                // Attack player
                                player.Health -= monster.Attack;
                                Console.WriteLine($"{monster.Name} dealt {monster.Attack}");
                            }  
                        }
                        else if (option_f == 2)
                        {
                            // Flee
                            break;
                        }
                        else if (option_f == 3)
                        {
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("Inventory:");

                            // Show inventory with numbers
                            for (int i = 0; i < player.inventory.Count; i++)
                            {
                                Weapon weapon = player.inventory[i];

                                if (weapon == player.Equiped)
                                {
                                    Console.WriteLine($"{i + 1}. {weapon.Name} (Equipped)");
                                }
                                else
                                {
                                    Console.WriteLine($"{i + 1}. {weapon.Name}");
                                }
                            }

                            Console.WriteLine("Select weapon number to equip:");

                            int choice = Convert.ToInt32(Console.ReadLine());

                            if (choice > 0 && choice <= player.inventory.Count())
                            {
                                player.Equiped = player.inventory[choice - 1];
                                Console.WriteLine($"You equipped {player.Equiped.Name}!");
                            }
                            else
                            {
                                Console.WriteLine("Wrong number dumb dumb.");
                            }
                        }
                    }

                    // monster or player dies
                    if (monster.Health <= 0) 
                    {
                        // monster dead
                        Console.WriteLine($"{monster.Name} is defeated");
                        player.CompleteQuestIfPossible(monster);
                    }
                    else if (player.Health <= 0)
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