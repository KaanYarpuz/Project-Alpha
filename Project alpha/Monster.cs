public class Monster
{
    // fields
    public int ID;
    public string Name;
    public int Attack;
    public int Health;
    public int RequiredQuestID;

    // Constructor
    public Monster (int C_id, string C_Name, int C_Attack, int C_Health, int C_RequiredQuestID)
    {
        ID = C_id;
        Name = C_Name;
        Attack = C_Attack;
        Health = C_Health;
        RequiredQuestID = C_RequiredQuestID;
    }

    public void Show_Description ()
    {
        Console.WriteLine($"{Name}:\nHealth: {Health}\nAttack: {Attack}");
    }
} 
