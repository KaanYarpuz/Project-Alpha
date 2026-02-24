namespace Project_Alpha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Game starting...");

            var locations = World.Locations;
            List<Monster> Monsters = World.Monsters;

            foreach (var location in locations)
            {
                Console.WriteLine($"Location: {location.Name}");
            }

            foreach (Monster monster in Monsters)
            {
                Console.WriteLine($"monster: {monster.Name}");
            }
            
            Console.WriteLine("World initialized.");
        }
    }
}