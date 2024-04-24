namespace VirtualPetSimulator;

public class HappyLevel
{
    public static void PlayWithYourPet(Pet pet)
    {
        Console.WriteLine("*Playing With Your Pet*");

        pet.petHappy += Random.Shared.Next(1, 5);

        if (pet.petHappy >= 100)
        {
            pet.petHappy = 100;
        }

        if (Program.CurrentTask.type == TaskTypes.PlayTask || Program.CurrentTask.type == TaskTypes.GeneralTask)
        {
            Program.CurrentTask.progression++;
        }

        Console.WriteLine("*Done Playing With Your Pet*");
        Console.ReadLine();
        Pet.PetUi();
    }
}