namespace Project_Alpha
{
    public class Player
    {
        // Fields
        public int Health;
        public List<Weapon> inventory = new List<Weapon>() {};

        public Weapon Equiped;

        public Location CurrentLocation;

        // Constructor
        public Player (int C_Health, Location C_CurrentLocation)
        {
            Health = C_Health;
            CurrentLocation = C_CurrentLocation;
        }

        public void Show_inv()
        {
            Console.WriteLine("items:");
            foreach (Weapon item in inventory)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }

        public void Move()
        {
            Console.WriteLine("Where do you want to go?");
            Console.WriteLine($"You are at {CurrentLocation.Name}");

            Console.WriteLine("    N");
            Console.WriteLine("    |");
            Console.WriteLine("W---|---E");
            Console.WriteLine("    |");
            Console.WriteLine("    S");
            bool moving = true;
            Location newLocation = null;


            while (moving)
            {
                string direction = Console.ReadLine().ToLower();
                if (direction == "n")
                    newLocation = CurrentLocation.LocationToNorth;

                else if (direction == "s")
                    newLocation = CurrentLocation.LocationToSouth;

                else if (direction == "e")
                    newLocation = CurrentLocation.LocationToEast;

                else if (direction == "w")
                    newLocation = CurrentLocation.LocationToWest;

                else
                {
                    Console.WriteLine("Invalid direction.");
                    return;
                }

                if (newLocation != null)
                {
                    CurrentLocation = newLocation;
                    Console.WriteLine($"You moved to {CurrentLocation.Name}");
                }
                else
                {
                    Console.WriteLine("You can't go that way.");
                }
            }

            
        }
    }
}
