namespace VirtualPetSimulator;

public class EventHandler
{
    public static Timer HungerTimer =
        new Timer(DecreaseHunger, null, TimeSpan.FromMinutes(2), Timeout.InfiniteTimeSpan);

    public static Timer HappyTimer =
        new Timer(DecreaseHappyLevel, null, TimeSpan.FromMinutes(2), Timeout.InfiniteTimeSpan);

    public static Timer AutoSaveTimer =
        new Timer(AutoSave, null, TimeSpan.FromMinutes(1), Timeout.InfiniteTimeSpan);

    public static bool IsHungerTimerActive = false;
    public static bool IsHappyTimerActive = false;
    public static bool IsAutoSaveTimerActive = false;

    private static void DecreaseHunger(object? state)
    {
        Program.CurrentPet.petHunger -= Program.CurrentPet switch
        {
            { hasFeedPet: false } => Random.Shared.Next(5, 10),
            _ => Random.Shared.Next(1, 5)
        };
        IsHungerTimerActive = false;
        Pet.PetUi();
    }

    private static void DecreaseHappyLevel(object? state)
    {
        Program.CurrentPet.petHappy -= Program.CurrentPet switch
        {
            { hasPlayedWithPet: false } => Random.Shared.Next(5, 10),
            _ => Random.Shared.Next(1, 5)
        };
        IsHappyTimerActive = false;
        Pet.PetUi();
    }

    private static void AutoSave(object? state)
    {
        Program.SavePet();
        Program.SaveTasks();
        Program.SaveInventory();
        IsAutoSaveTimerActive = false;
    }
}