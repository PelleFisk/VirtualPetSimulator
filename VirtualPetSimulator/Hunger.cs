namespace VirtualPetSimulator;

public class Hunger
{
    public static void FeedYourPet(Pet pet)
    {
        foreach (var food in Program.Foods)
        {
            Console.WriteLine("=================");
            Console.WriteLine($"Food Id: {food.id}");
            Console.WriteLine($"Food Name: {food.name}");
            Console.WriteLine($"Food Filling Level: {food.fillingLevel}");
            Console.WriteLine($"Food Uses: {food.uses}");
            Console.WriteLine("=================");

            Console.WriteLine("Please enter in the id of the food you want to use");
            Console.Write("> ");
            if (int.TryParse(Console.ReadLine()!, out int id))
            {
                var foodToFeed = Program.Foods.Find(f => f.id == id);
                if (foodToFeed != null)
                {
                    Console.WriteLine("*Feeding Your Pet*");

                    pet.petHunger += food.fillingLevel;
                    food.uses--;

                    if (pet.petHunger >= 100)
                    {
                        pet.petHunger = 100;
                    }

                    if (Program.CurrentTask.type == TaskTypes.PlayTask ||
                        Program.CurrentTask.type == TaskTypes.GeneralTask)
                    {
                        Program.CurrentTask.progression++;
                    }

                    Console.WriteLine("*Done Feeding Your Pet*");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("There's no food with that id");
                }
            }
        }

        Pet.PetUi();
    }
}