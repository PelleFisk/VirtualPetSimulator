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

    public static void BuyNewPet()
    {
    }

    public static int GetCost()
    {
        return Random.Shared.Next(100, 200);
    }
}