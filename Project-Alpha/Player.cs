namespace Project_Alpha
{
    public class Player
    {
        // Fields
        public int Health;
        public List<Weapon> inventory = new List<Weapon>() {};

        public Weapon Equiped;

        // Constructor
        public Player (int C_Health)
        {
            Health = C_Health;
        }

        public void Show_inv()
        {
            Console.WriteLine("items:");
            foreach (Weapon item in inventory)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }
    }
}
