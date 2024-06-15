using System;
using System.Collections.Generic;
using System.Transactions;

namespace ATMApplication
{
    // Define the Account class
    public class BankAccount
    {
        // Properties
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public double InterestRate { get; set; }
        public string AccountHolderName { get; set; }

        public List<string> Transactions;

        // Constructor
        public BankAccount(int accountNumber, decimal initialBalance, double interestRate, string accountHolderName)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            InterestRate = interestRate;
            AccountHolderName = accountHolderName;
            Transactions = new List<string> { $"Account created with balance {initialBalance:C}" }; ;
        }

        // Method to deposit money
        public void Deposit(decimal amount)
        {
            Balance += amount;
            Transactions.Add($"Deposit: +{amount}");
        }

        // Method to withdraw money
        public bool Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Transactions.Add($"Withdrew {amount:C}");
                return true;
            }
            return false;
        }

        public List<string> GetTransactions()
        {
            return Transactions;
        }

        // Method to calculate interest
        public decimal CalculateInterest()
        {
            return Balance * (decimal)(InterestRate / 100);
        }
    }
}

