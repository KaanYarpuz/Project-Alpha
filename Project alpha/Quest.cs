namespace Project_Alpha
{
    public class Quest
    {
        public int ID; 
        public string TITLE; 
        public string TASK; 
        
        public Quest(int id, string title, string task)
        {
            ID = id; 
            TITLE = title; 
            TASK = task; 
            
        }
        public Weapon Randomweapon()
        {
            int randomnumber = new Random().Next(World.Weapons.Count());

            return World.Weapons[randomnumber];
        }

        public bool startquest_or_not()
        {
            Console.WriteLine($"Do you want to start the quest {TITLE} or not? ansswer in Y/N");

            while (true)

            {

            string antwoord = Console.ReadLine().ToUpper(); 
            if (antwoord == "Y") {return true;}

            else if (antwoord == "N") {return false;}

            else Console.WriteLine("Write a Y or N, not something else");

            }
        }
        }
    }
