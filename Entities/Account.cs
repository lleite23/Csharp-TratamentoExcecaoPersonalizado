using ExceptionHandling_1.Entities.Exceptions;

namespace ExceptionHandling_1.Entities
{
    class Account
    {
        public int Number { get; set; } // Número da conta
        public string Holder { get; set; } // Titular da conta
        public double Balance { get; set; } // Saldo
        public double WithdrawLimit { get; set; } // Limite de saque

        public Account()
        {

        }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void deposit(double amount)
        {
            Balance = amount;
        }

        public void withdraw(double amount)
        {
            if (amount > WithdrawLimit) 
            {
                throw new DomainExceptions("The amount exceeds withdraw limit");
            }
            if (amount <= WithdrawLimit && amount > Balance)
            {
                throw new DomainExceptions("Not enough balance");
            }
         
            Balance -= amount;
        }
    }
}
