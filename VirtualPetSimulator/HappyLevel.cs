namespace VirtualPetSimulator;

public class HappyLevel
{
    public static void PlayWithYourPet(Pet pet)
    {
        foreach (var toy in Program.Toys)
        {
            Console.WriteLine("=================");
            Console.WriteLine($"Toy Id: {toy.id}");
            Console.WriteLine($"Toy Name: {toy.name}");
            Console.WriteLine($"Toy Happy Level: {toy.happyLevel}");
            Console.WriteLine($"Toy Uses: {toy.uses}");
            Console.WriteLine("=================");

            Console.WriteLine("Please enetr in the id of the toy you want to use");
            Console.Write("> ");
            if (int.TryParse(Console.ReadLine()!, out int id))
            {
                var toyToPLayWith = Program.Toys.Find(t => t.id == id);
                if (toyToPLayWith != null)
                {
                    Console.WriteLine("*Playing With Your Pet*");

                    pet.petHappy += toy.happyLevel;
                    toy.uses--;

                    if (pet.petHappy >= 100)
                    {
                        pet.petHappy = 100;
                    }

                    if (Program.CurrentTask.type == TaskTypes.PlayTask ||
                        Program.CurrentTask.type == TaskTypes.GeneralTask)
                    {
                        Program.CurrentTask.progression++;
                    }

                    Console.WriteLine("*Done Playing With Your Pet*");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("There's no toy with that id");
                }
            }
        }

        Pet.PetUi();
    }
}