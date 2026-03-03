using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_Alpha
{
    public class Player
    {
        // Fields
        public int Health;
        public List<Weapon> inventory = new List<Weapon>();

        public Weapon Equiped;

        public Location CurrentLocation;

        public List<int> CompletedQuests = new List<int>();
        public List<int> ActiveQuests = new List<int>();

        // Constructor
        public Player(int C_Health, Location C_CurrentLocation)
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


            // if (CurrentLocation.MonsterLivingHere != null)
            // {
            //     gevecht();
            // }
        }  

        public void HandleLocationEvents()
        {
            if (CurrentLocation.QuestAvailableHere != null)
            {
                Quest quest = CurrentLocation.QuestAvailableHere;

                if (!CompletedQuests.Contains(quest.ID) && !ActiveQuests.Contains(quest.ID))
                {

                    if (quest.startquest_or_not())
                    {
                        ActiveQuests.Add(quest.ID);
                        Console.WriteLine($"You have started the quest: {quest.TITLE}");
                        Console.WriteLine($"Task: {quest.TASK}");
                    }
                    else
                    {
                        Console.WriteLine($"You declined the quest: {quest.TITLE}");
                    }

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

            if (monster.ID == World.MONSTER_ID_GIANT_SPIDER && 
            ActiveQuests.Contains(World.QUEST_ID_COLLECT_SPIDER_SILK))

            {
                FinishQuest(World.QUEST_ID_COLLECT_SPIDER_SILK);
            }


        }

        private void FinishQuest(int questID)
        {
            ActiveQuests.Remove(questID);
            CompletedQuests.Add(questID);

            Console.WriteLine("Quest Completed!");
        }

        public void gevecht()
        {
            Monster? monster = CurrentLocation.MonsterLivingHere;

            if (monster == null)
            {
                Console.WriteLine("There is nothong to fight here");
                return;
            }

            if (monster.RequiredQuestID != 0 &&
                !ActiveQuests.Contains(monster.RequiredQuestID))
                {
                    Console.WriteLine("You haven't started the quest for this location yet batty boy!");
                    return;
                }
            
            // Fight
            while (monster.Health > 0 && this.Health > 0)
            {

                Console.WriteLine("-------------------------------");
                monster.Show_Description();

                Console.WriteLine("-------------------------------");
                Console.WriteLine($"Player health: {this.Health}");

                Console.WriteLine("[1]: Attack\n[2]: Flee\n[3]: view inventory/change weapon");
                
                int option_f = Convert.ToInt32(Console.ReadLine()); 
                
                if (option_f == 1)
                {

                    monster.Health -= this.Equiped.Damage;
                    Console.WriteLine($"You deal {this.Equiped.Damage}");
                    
                    if (monster.Health > 0)
                    {

                        TakeDamage(monster.Attack);
                        Console.WriteLine($"{monster.Name} dealt {monster.Attack}");
                    
                    if (Health <= 0)
                        {
                            Console.WriteLine("Game over");
                            World.gameWin = true;
                            return;
                        }
                    
                    }  
                }
                else if (option_f == 2)
                {
                    // Flee
                    Console.WriteLine("Lil bitch flees");
                    return;
                }
                else if (option_f == 3)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Inventory:");


                    this.Show_inv();

                    Console.WriteLine("Select weapon number to equip:");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice > 0 && choice <= this.inventory.Count)
                    {
                        this.Equiped = this.inventory[choice - 1];
                        Console.WriteLine($"You equipped {this.Equiped.Name}!");
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
                CompleteQuestIfPossible(monster);
                // game win
                if (monster.Name == "giant spider")
                {
                    Console.WriteLine("Congratzz you won"); 
                    World.gameWin = true;
                }
            }
            else if (Health <= 0)
            {
                // player dead
                Console.WriteLine($"Weak twink ass beta ahh, your 6 feet under");
                World.gameWin = true;
                return;
            }
        }
        public void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health < 0)
            Health = 0;
        }
    }
}