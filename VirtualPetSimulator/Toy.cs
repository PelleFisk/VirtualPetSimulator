namespace VirtualPetSimulator;

public class Toy(string description, int id, int happyLevel, int uses)
{
    public string description { get; set; } = description;
    public int id { get; set; } = id;
    public int happyLevel { get; set; } = happyLevel;
    public int uses { get; set; } = uses;

    public static int GetHappyLevel()
    {
        return Random.Shared.Next(5, 10);
    }
}