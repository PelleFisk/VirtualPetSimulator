using System.Text.Json;

namespace VirtualPetSimulator;

public class Program
{
    static readonly string SaveDir = Environment.CurrentDirectory + @"\VirtualPetSimulatorSaves\";

    public static List<Pet> Pets = [];
    public static Pet CurrentPet = new Pet("", "", 0, 0, 0, false, false, false);
    public static Tasks CurrentTask = Tasks.CreateTask();
    public static List<Food> foods = new List<Food>();
    public static List<Toy> toys = new List<Toy>();

    public static void Main()
    {
        if (!Directory.Exists(SaveDir))
        {
            Directory.CreateDirectory(SaveDir);
            CreateStarterProfile();
        }

        LoadPet();
        LoadTasks();
        LoadInventory();
        Pet.PetUi();
    }

    private static void CreateStarterProfile()
    {
        Console.WriteLine("Welcome to my virtual pet simulator");
        Console.WriteLine(
            "I see that you're new to my game so I will go through the basics of creating your first pet");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("So first you will need to give your pet a name");
        Console.Write("> ");

        string name = Console.ReadLine()!;

        Console.WriteLine("Now that your animal has a name, you will now need to choose a type of animal");
        Console.WriteLine("Please enter in one of the folowing number corresponding to the type you want");
        Console.WriteLine("0: Dog");
        Console.WriteLine("1: Cat");
        Console.WriteLine("2: Bird");
        Console.WriteLine("3: Fish");
        Console.Write("> ");

        string petType = Console.ReadLine()! switch
        {
            "0" => "Dog",
            "1" => "Cat",
            "2" => "Bird",
            "3" => "Fish",
            _ => ""
        };

        Pets.Add(new Pet(name, petType, 100, 100, 0, true, false, false));
        foods.Add(new Food($"{petType} Food", 0, Food.GetFillingLevel(), 10));
        toys.Add(new Toy($"{petType} Toy", 0, Toy.GetHappyLevel(), 10));

        SavePet();
        SaveTasks();
        SaveInventory();
    }

    // Saves the progress the player has made
    public static void SavePet()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(Pets, options);
        string path = SaveDir + "Saves.json";
        File.WriteAllText(path, json);
    }

    public static void SaveTasks()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(CurrentTask, options);
        string path = SaveDir + "Tasks.json";
        File.WriteAllText(path, json);
    }

    public static void SaveInventory()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string foodJson = JsonSerializer.Serialize(foods, options);
        string toyJson = JsonSerializer.Serialize(toys, options);
        string foodPath = SaveDir + "Food.json";
        string toyPath = SaveDir + "Toy.json";
        File.WriteAllText(foodPath, foodJson);
        File.WriteAllText(toyPath, toyJson);
    }

    // Loads at start
    private static void LoadPet()
    {
        string loadedJson = File.ReadAllText(SaveDir + "Saves.json");
        Pets = JsonSerializer.Deserialize<List<Pet>>(loadedJson)!;
        CurrentPet = Pets.Find(p => p.currentPet)!;
    }

    private static void LoadTasks()
    {
        string loadedJson = File.ReadAllText(SaveDir + "Tasks.json");
        CurrentTask = JsonSerializer.Deserialize<Tasks>(loadedJson)!;
    }

    private static void LoadInventory()
    {
        string foodJson = File.ReadAllText(SaveDir + "Food.json");
        string toyJson = File.ReadAllText(SaveDir + "Toy.json");
        foods = JsonSerializer.Deserialize<List<Food>>(foodJson)!;
        toys = JsonSerializer.Deserialize<List<Toy>>(toyJson)!;
    }
}