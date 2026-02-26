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

        public void quest_completion(int id, string title, string task)
        {
            if (World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN == id) {Console.WriteLine($"Do you want to start the quest clear alchemist garden and accomplish it?");
            bool doorgaan = false; 
            while (!doorgaan)
            {string antwoord = Console.ReadLine(); if (antwoord == "Y") {Console.WriteLine($"You're now going to Clear the alchemist's garden?"); 
            doorgaan = true;}
            else if (antwoord == "N") {Console.WriteLine("You eventually need to overcome your fears to win"); doorgaan = true;} 
            else {Console.WriteLine("Fill in either Y or N");}}}

            else if (World.QUEST_ID_CLEAR_FARMERS_FIELD == id) {Console.WriteLine($"Do you want to start clear farmers field and accomplish it?");
            bool doorgaan = false; 
            while (!doorgaan)
            {string antwoord = Console.ReadLine(); if (antwoord == "Y") {Console.WriteLine($"You're now going to Clear the farmers field?"); doorgaan = true;}
            else if (antwoord == "N") {Console.WriteLine("You eventually need to overcome your fears to win"); doorgaan = true;} 
            else {Console.WriteLine("Fill in either Y or N");}}}

            else if (World.QUEST_ID_COLLECT_SPIDER_SILK == id) {Console.WriteLine($"Do you want to collect spider silk and accomplish this task?");
            bool doorgaan = false; 
            while (!doorgaan)
            {string antwoord = Console.ReadLine(); if (antwoord == "Y") {Console.WriteLine($"You're now going to collect spider silk?"); doorgaan = true;}
            else if (antwoord == "N") {Console.WriteLine("You eventually need to overcome your fears to win"); doorgaan = true;} 
            else {Console.WriteLine("Fill in either Y or N");}}}
        }
    }
}