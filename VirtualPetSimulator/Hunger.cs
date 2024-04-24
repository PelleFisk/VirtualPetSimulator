namespace VirtualPetSimulator;

public class Hunger
{
    public static void FeedYourPet(Pet pet)
    {
        Console.WriteLine("*Feeding Pet*");

        pet.petHunger += Random.Shared.Next(1, 5);

        if (pet.petHunger >= 100)
        {
            pet.petHunger = 100;
        }

        if (Program.CurrentTask.type == TaskTypes.FeedTask || Program.CurrentTask.type == TaskTypes.GeneralTask)
        {
            Program.CurrentTask.progression++;
        }

        Console.WriteLine("*Done Feeding Pet*");
        Console.ReadLine();
        Pet.PetUi();
    }
}