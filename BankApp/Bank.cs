using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Bank
    {
        //Denna uppgift skall ha enhetstester men inget krav på att använda
        //TDD
        //Bygg en enkel konsolapplikation där användaren kan skapa ett
        //bankkonto och sätta in och ta ut pengar.
        //• Bankkonto ska ha ett namn, kontonummer och saldo.
        //• Saldo ska inte kunna hamna på minus
        //Extra:
        //• Skicka pengar till annat bankkonto (verifiera att det är ett giltigt
        //kontonummer, hitta på egna regler för detta, eller ta något befintligt)

        public string AccountName { get; set; }
        public string AccountNumber { get; }
        public double Balance { get; set; }

        public Bank(string accountName, string accountNumber)
        {
            AccountName = accountName;
            AccountNumber = accountNumber;
            Balance = 0;
        }

        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Överförde {amount:C}. Nytt saldo: {Balance:C}");
                return true;
            }
            else
            {
                Console.WriteLine("Ogiltig överföringssumma.");
                return false;
            }
        }

        public bool Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Tog ut {amount:C}. Nytt saldo: {Balance:C}");
                return true;
            }
            else
            {
                Console.WriteLine("Ogiltig uttag, summan överskred saldot.");
                return false;
            }
        }

        public bool Transfer(Bank recipient, double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                recipient.Balance += amount;
                Console.WriteLine($"Överförde {amount:C} till {recipient.AccountName}. Din nya saldo: {Balance:C}");
                return true;
            }

            else
            {
                Console.WriteLine("Ogiltig överföring, summan överskred saldot.");
                return false;
            }
        }
    }

}