using System.Security.Principal;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Bank> accounts = new List<Bank>();

            while (true)
            {
                Console.WriteLine("1. Skapa ett nytt konto");
                Console.WriteLine("2. Se alla konton");
                Console.WriteLine("3. Överför pengar");
                Console.WriteLine("4. Ta ut pengar");
                Console.WriteLine("5. Överför pengar till annat konto");
                Console.WriteLine("6. Exit");
                Console.Write("Ange ditt val: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Ange ett namn på kontot: ");
                            string accountName = Console.ReadLine();
                            Console.Write("Ange ett kontonummer: ");
                            string accountNumber = Console.ReadLine();
                            Bank newAccount = new Bank(accountName, accountNumber);
                            accounts.Add(newAccount);
                            Console.WriteLine("Lyckades att skapa konto!");
                            break;
                        case 2:
                            if(accounts.Count > 0)
                            {
                                foreach(var account in accounts)
                                {
                                    Console.WriteLine($"Kontonamn: {account.AccountName} " +
                                        $"Kontonummer: {account.AccountNumber} " +
                                        $"Saldo: {account.Balance}");
                                }
                            }
                            else 
                            {
                                Console.WriteLine("Finns inga konton för tillfället.");
                            }
                            break;
                        case 3:
                            Console.Write("Ange ett kontonummer:");
                            string depositAccountNumber = Console.ReadLine();
                            var depositAccount = accounts.Find(x => x.AccountNumber == depositAccountNumber);
                            if (depositAccount != null)
                            {
                                Console.Write("Ange summan som ska överföras: ");
                                if (double.TryParse(Console.ReadLine(), out double depositAmount))
                                {
                                    depositAccount.Deposit(depositAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Ogiltig inmatning för insättningsbelopp.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Kontot hittades inte.");
                            }
                            break;
                        case 4:
                            Console.Write("Ange kontonummer: ");
                            string withdrawAccountNumber = Console.ReadLine();
                            var withdrawAccount = accounts.Find(x => x.AccountNumber == withdrawAccountNumber);
                            if (withdrawAccount != null)
                            {
                                Console.Write("Ange summan du vill ta ut: ");
                                if (double.TryParse(Console.ReadLine(), out double withdrawalAmount))
                                {
                                    withdrawAccount.Withdraw(withdrawalAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Ogiltig summa för uttag.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Kontot hittades inte");
                            }
                            break;
                        case 5:
                            Console.Write("Ange ditt konto nummer: ");
                            string senderAccountNumber = Console.ReadLine();
                            var senderAccount = accounts.Find(x => x.AccountNumber == senderAccountNumber);
                            if (senderAccount != null)
                            {
                                Console.Write("Ange mottagarens kontonummer: ");
                                string recipientAccountNumber = Console.ReadLine();
                                var recipientAccount = accounts.Find(x => x.AccountNumber == recipientAccountNumber);
                                if (recipientAccount != null)
                                {
                                    Console.Write("Ange summan du vill överföra: ");
                                    if (double.TryParse(Console.ReadLine(), out double transferAmount))
                                    {
                                        senderAccount.Transfer(recipientAccount, transferAmount);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ogiltig summa för överföring.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Mottagarens konto hittades inte.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Kontot hittades inte.");
                            }
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Vänligen ange ett giltigt val.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Vänligen ange ett giltigt nummer.");
                }
            }
        }
    }
}