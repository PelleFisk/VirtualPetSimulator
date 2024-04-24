namespace VirtualPetSimulator;

public class Food(string description, int id, int fillingLevel, int uses)
{
    public string description { get; set; } = description;
    public int id { get; set; } = id;
    public int fillingLevel { get; set; } = fillingLevel;
    public int uses { get; set; } = uses;

    public static int GetFillingLevel()
    {
        return Random.Shared.Next(5, 10);
    }
}