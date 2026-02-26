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
            Console.WriteLine("Items:");
            for (int i = 0; i < inventory.Count; i++)
            {
                Weapon item = inventory[i];

                if (item == Equiped)
                {
                    Console.WriteLine($"{i + 1}. {item.Name} (Equipped)");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {item.Name}");
                }
            }
        }
    }
}
