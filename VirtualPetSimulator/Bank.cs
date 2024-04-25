namespace VirtualPetSimulator;

public class Bank
{
    public int money { get; set; }
    public int balance { get; set; }

    public static void BankUi()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============");
            Console.WriteLine("1: Deposit Money");
            Console.WriteLine("2: Withdraw Money");
            Console.WriteLine("3: Check Balance");
            Console.WriteLine("4: Exit Bank");
            Console.WriteLine("==============");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    DepositMoney();
                    break;
                case "2":
                    WithdrawMoney();
                    break;
                case "3":
                    ShowBalance();
                    break;
                case "4":
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

    private static void DepositMoney()
    {
        Console.WriteLine("How much would you like to deposit?");
        Console.Write("> ");
        int depositAmount = Convert.ToInt32(Console.ReadLine());

        Program.bank.money -= depositAmount switch
        {
            < 0 => 0,
            _ => depositAmount
        };

        Program.bank.balance += depositAmount switch
        {
            < 0 => 0,
            _ => depositAmount
        };

        BankUi();
    }

    private static void WithdrawMoney()
    {
        Console.WriteLine("How much would you like to withdraw?");
        Console.Write("> ");
        int withdrawAmount = Convert.ToInt32(Console.ReadLine());

        Program.bank.money += withdrawAmount switch
        {
            < 0 => 0,
            _ => withdrawAmount
        };

        Program.bank.balance -= withdrawAmount switch
        {
            < 0 => 0,
            _ => withdrawAmount
        };

        BankUi();
    }

    private static void ShowBalance()
    {
        Console.WriteLine($"Balance: {Program.bank.balance}");
        Console.ReadLine();
        BankUi();
    }
}