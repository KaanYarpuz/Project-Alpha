namespace Project_Alpha
{
    public class Player
    {
        // Fields
        public int Health;
        public List<Weapon> inventory = new List<Weapon>() {};

        // Constructor
        public Player (int C_Health)
        {
            Health = C_Health;
        }

        public void Show_inv()
        {
            foreach (Weapon item in inventory)
            {
                Console.WriteLine($": {item.Name}");
            }
        }
    }
}
