namespace VirtualPetSimulator;

public class Food(string name, int id, int fillingLevel, int uses)
{
    public string name { get; set; } = name;
    public int id { get; set; } = id;
    public int fillingLevel { get; set; } = fillingLevel;
    public int uses { get; set; } = uses;

    public static int GetFillingLevel()
    {
        return Random.Shared.Next(5, 10);
    }
}