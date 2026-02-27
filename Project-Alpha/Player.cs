namespace Project_Alpha
{
    public class Player
    {
        // Fields
        public int Health;
        public List<Weapon> inventory = new List<Weapon>() {};

        public Weapon Equiped;

        public Location CurrentLocation;

        public List<int> CompletedQuests = new List<int>();
        public List<int> ActiveQuests = new List<int>();

        // Constructor
        public Player (int C_Health, Location C_CurrentLocation)
        {
            Health = C_Health;
            CurrentLocation = C_CurrentLocation;
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

        public void Move()
        {
            Console.WriteLine("Where do you want to go?");
            Console.WriteLine($"You are at {CurrentLocation.Name}");

            Console.WriteLine("    N");
            Console.WriteLine("    |");
            Console.WriteLine("W---|---E");
            Console.WriteLine("    |");
            Console.WriteLine("    S");
            Console.WriteLine($"Active Quests: {ActiveQuests.Count}");
            Console.WriteLine($"Completed Quests: {CompletedQuests.Count}");
            Location? newLocation = null;


            
            
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

            if (newLocation == null)
            {
                Console.WriteLine("You can't go that way.");
                return;
            }

            if (newLocation.ID == World.LOCATION_ID_GUARD_POST)
            {
                if (!CompletedQuests.Contains(World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN) || !CompletedQuests.Contains(World.QUEST_ID_CLEAR_FARMERS_FIELD))
                {
                    Console.WriteLine("The guard stops you and says: 'You can't pass until you clear the alchemist's garden and the farmer's field!'");
                    newLocation = World.LocationByID(World.LOCATION_ID_TOWN_SQUARE);
                }
                else
                    {
                        Console.WriteLine("Guard: You may pass, hero.");
                    }
            }
            CurrentLocation = newLocation;
            Console.WriteLine($"You moved to {CurrentLocation.Name}");
            HandleLocationEvents();
        }  
    

        public void HandleLocationEvents()
        {
            if (CurrentLocation.QuestAvailableHere != null)
            {
                Quest quest = CurrentLocation.QuestAvailableHere;

                if (!CompletedQuests.Contains(quest.ID) && !ActiveQuests.Contains(quest.ID))
                {
                    ActiveQuests.Add(quest.ID);
                    Console.WriteLine($"You have started the quest: {quest.TITLE}");
                    Console.WriteLine($"Task: {quest.TASK}");
                }
            }
        }


        public void CompleteQuestIfPossible(Monster monster)
        {
            if (monster.ID == World.MONSTER_ID_RAT &&
                ActiveQuests.Contains(World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN))
            {
                FinishQuest(World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN);
            }

            if (monster.ID == World.MONSTER_ID_SNAKE &&
                ActiveQuests.Contains(World.QUEST_ID_CLEAR_FARMERS_FIELD))
            {
                FinishQuest(World.QUEST_ID_CLEAR_FARMERS_FIELD);
            }
        }

        private void FinishQuest(int questID)
        {
            ActiveQuests.Remove(questID);
            CompletedQuests.Add(questID);

            Console.WriteLine("Quest Completed!");
        }
    }
}
