namespace VirtualPetSimulator;

[Serializable]
public class Pet(
    string? name,
    string? petType,
    int petHunger,
    int petHappy,
    bool currentPet,
    bool hasFeedPet,
    bool hasPlayedWithPet)
{
    public string? name { get; set; } = name;
    public string? petType { get; set; } = petType;
    public int petHunger { get; set; } = petHunger;
    public int petHappy { get; set; } = petHappy;
    public bool currentPet { get; set; } = currentPet;
    public bool hasFeedPet { get; set; } = hasFeedPet;
    public bool hasPlayedWithPet { get; set; } = hasPlayedWithPet;

    public static void PetUi()
    {
        if (Tasks.TaskCompleted())
        {
            AddColorToTerminal.AddColor("Task Completed", ConsoleColor.Magenta);
            Console.ReadLine();
            Program.CurrentTask.completed = true;
            Tasks.GetReward();
            Program.CurrentTask = Tasks.CreateTask();
        }

        Tasks.TaskCompleted();

        if (!EventHandler.IsHungerTimerActive)
        {
            EventHandler.HungerTimer.Change(TimeSpan.FromMinutes(2), TimeSpan.FromMinutes(2));
            EventHandler.IsHungerTimerActive = true;
        }

        if (!EventHandler.IsHappyTimerActive)
        {
            EventHandler.HappyTimer.Change(TimeSpan.FromMinutes(2), TimeSpan.FromMinutes(2));
            EventHandler.IsHappyTimerActive = true;
        }

        if (!EventHandler.IsAutoSaveTimerActive)
        {
            EventHandler.AutoSaveTimer.Change(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
            EventHandler.IsAutoSaveTimerActive = true;
        }

        Console.Clear();
        Console.WriteLine("=================");
        Console.WriteLine($"Pet Name: {Program.CurrentPet.name}");
        Console.WriteLine($"Pet Type: {Program.CurrentPet.petType}");
        AddColorToTerminal.AddColor($"Hunger: {Program.CurrentPet.petHunger}%", ConsoleColor.Red);
        AddColorToTerminal.AddColor($"Happy: {Program.CurrentPet.petHappy}%", ConsoleColor.Yellow);
        Console.WriteLine($"Money: {Program.Data.Money}");
        Console.WriteLine("=================");

        Console.WriteLine("What do you wish to do?");
        Console.WriteLine("0: Feed Your Pet");
        Console.WriteLine("1: Play With Your Pet");
        Console.WriteLine("2: Check Tasks");
        Console.WriteLine("3: Go To The Shop");
        Console.WriteLine("4: Go To The Pet Shop");
        Console.WriteLine("5: Exit The Game");
        Console.Write("> ");

        var input = Console.ReadLine();

        switch (input)
        {
            case "0":
                Hunger.FeedYourPet(Program.CurrentPet);
                break;
            case "1":
                HappyLevel.PlayWithYourPet(Program.CurrentPet);
                break;
            case "2":
                Tasks.TaskUi();
                break;
            case "3":
                Shop.ShopUi();
                break;
            case "4":
                PetShop.PetShopUi();
                break;
            case "5":
                Program.SavePet();
                Program.SaveTasks();
                Program.SaveInventory();
                Program.SavePetTypes();
                Program.SaveGlobalData();
                break;
        }
    }
}