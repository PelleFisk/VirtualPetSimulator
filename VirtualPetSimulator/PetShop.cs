namespace VirtualPetSimulator;

public class PetShop
{
    public static void PetShopUi()
    {
        while (true)
        {
            Console.WriteLine($"Money: {Program.bank.money}");
            Console.WriteLine("==============");
            Console.WriteLine("1: Buy New Pet");
            Console.WriteLine("2: Unlock Pet Types");
            Console.WriteLine("3: Exit Pet Shop");
            Console.WriteLine("==============");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    BuyNewPet();
                    break;
                case "2":
                    break;
                case "3":
                    Pet.PetUi();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Console.ReadLine();
                    continue;
            }

            break;
        }
    }

    private static void BuyNewPet()
    {
        int cost1 = GetCost();
        int cost2 = GetCost();
        int cost3 = GetCost();
        // string petType1 = GetPetType();
        // string petType2 = GetPetType();
        // string petType3 = GetPetType();

        Console.WriteLine($"First Pet Cost: {cost1}");
        // Console.WriteLine($"First Pet Type: {petType1}");
        Console.WriteLine($"Second Pet Cost: {cost2}");
        // Console.WriteLine($"Second Pet Type: {petType2}");
        Console.WriteLine($"Third Pet Cost: {cost3}");
        // Console.WriteLine($"Third Pet Type: {petType3}");
        Console.WriteLine("Please enter the number of the pet you would like to buy(1/2/3) or 'q' to quit the shop");
        Console.Write("> ");

        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                // BuyPet(cost1, petType1);
                break;
            case "2":
                // BuyPet(cost2, petType2);
                break;
            case "3":
                // BuyPet(cost3, petType3);
                break;
            case "q":
                PetShopUi();
                break;
        }
    }

    private static void BuyPet(int cost, string petType)
    {
        if (Program.bank.money >= cost)
        {
            Console.WriteLine("Please give your new pet a name");
            Console.Write("> ");

            string name = Console.ReadLine()!;

            Program.Pets.Add(new Pet(name, petType, 100, 100, true, false, false));

            PetShopUi();
        }
        else
        {
            Console.WriteLine("You do not have enough money to buy a pet");
            Console.ReadLine();
            PetShopUi();
        }
    }

    private static int GetCost()
    {
        return Random.Shared.Next(100, 200);
    }

    private static string GetPetType()
    {
        int num = Random.Shared.Next(0, Program.unlockedPetTypes.Count());
        return Program.unlockedPetTypes[num].ToString()!;
    }
}