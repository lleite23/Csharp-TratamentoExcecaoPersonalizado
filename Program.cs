using ExceptionHandling_1.Entities;
using ExceptionHandling_1.Entities.Exceptions;
using System;
using System.Globalization;

namespace ExceptionHandling_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                System.Console.WriteLine("Enter account data");
                System.Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                System.Console.Write("Holder: ");
                string holder = Console.ReadLine();
                System.Console.Write("Initial balance: ");
                double initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                System.Console.Write("Withdraw limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine();
                System.Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account account = new Account(number, holder, initialBalance, withdrawLimit);
                account.withdraw(amount);

                Console.WriteLine("New balance: " + account.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (DomainExceptions e) // Tratamento de exceção personalizada
            {
                Console.WriteLine("Withdraw error: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid format: " + e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
