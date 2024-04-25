namespace VirtualPetSimulator;

public class PetUnlockRequirement(int requiredTasksCompleted)
{
    public int requiredTasksCompleted { get; set; } = requiredTasksCompleted;

    public static PetUnlockRequirement AddPetUnlockRequirement(int requiredTasksCompleted)
    {
        return new PetUnlockRequirement(requiredTasksCompleted);
    }
}