namespace VirtualPetSimulator;

public class PetType(string type, PetUnlockRequirement requirement)
{
    public string type { get; set; } = type;
    public PetUnlockRequirement requirement { get; set; } = requirement;

    public static PetType AddPetType(string type, PetUnlockRequirement requirement)
    {
        return new PetType(type, requirement);
    }

    public static List<PetType> AddDefaultPetTypes()
    {
        return new List<PetType>([
            new PetType("Dog", PetUnlockRequirement.AddPetUnlockRequirement(0)),
            new PetType("Cat", PetUnlockRequirement.AddPetUnlockRequirement(0)),
            new PetType("Bird", PetUnlockRequirement.AddPetUnlockRequirement(0)),
            new PetType("Fish", PetUnlockRequirement.AddPetUnlockRequirement(0))
        ]);
    }

    public static bool CheckPetUnlockRequirement(PetUnlockRequirement requirement)
    {
        return Program.Data.TasksCompleted >= requirement.requiredTasksCompleted;
    }
}