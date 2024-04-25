namespace VirtualPetSimulator;

public class Shop
{
    public static void ShopUi()
    {
        while (true)
        {
            // Console.WriteLine($"Money: {Program.CurrentPet.money}");
            Console.WriteLine("==============");
            Console.WriteLine("1: Buy Food");
            Console.WriteLine("2: Buy Toy");
            Console.WriteLine("3: Exit Shop");
            Console.WriteLine("==============");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    // BuyFood();
                    break;
                case "2":
                    // BuyToy();
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

    public static void BuyFood()
    {
        int cost = GetCostOfItem();
        if (Program.bank.money >= cost)
        {
            Program.bank.money -= cost;
            Console.WriteLine("You bought food for your pet");
            Program.Foods.Add(new Food($"{Program.CurrentPet.petType} Food", Program.Foods.Count(),
                Food.GetFillingLevel(), GetUses()));
            Console.ReadLine();
            ShopUi();
        }
        else
        {
            Console.WriteLine("You do not have enough money to buy food");
            Console.ReadLine();
            ShopUi();
        }
    }

    public static void BuyToy()
    {
        int cost = GetCostOfItem();
        if (Program.bank.money >= cost)
        {
            Program.bank.money -= cost;
            Console.WriteLine("You bought a toy for your pet");
            Program.Toys.Add(new Toy($"{Program.CurrentPet.petType} Toy", Program.Toys.Count(), Toy.GetHappyLevel(),
                GetUses()));
            Console.ReadLine();
            ShopUi();
        }
        else
        {
            Console.WriteLine("You do not have enough money to buy a toy");
            Console.ReadLine();
            ShopUi();
        }
    }

    private static int GetCostOfItem()
    {
        return Random.Shared.Next(10, 20);
    }

    private static int GetUses()
    {
        return Random.Shared.Next(5, 10);
    }
}