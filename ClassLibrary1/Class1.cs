using System;
using System.Collections.Generic;

namespace ATMApplication
{
    // Define the ATM Application class
    public class ATMApplication
    {
        private Bank bank;

        public ATMApplication()
        {
            bank = new Bank();
        }

        // Method to display the ATM Main Menu
        public void DisplayMainMenu()
        {
            Console.WriteLine("ATM Main Menu");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Select Account");
            Console.WriteLine("3. Exit");
        }

        // Method to display the Account Menu
        public void DisplayAccountMenu()
        {
            Console.WriteLine("Account Menu");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Display Transactions");
            Console.WriteLine("5. Exit Account");
        }

        // Method to run the ATM application
        public void Run()
        {
            int choice;
            do
            {
                DisplayMainMenu(); // Display the main menu options to the user
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Create Account
                        CreateAccount();
                        break;
                    case 2:
                        // Select Account
                        SelectAccount();
                        break;
                    case 3:
                        // Exit
                        Console.WriteLine("Exiting ATM application.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 3); // Continue looping until the user chooses to exit (choice 3)
        }

        // Method to create a new account
        private void CreateAccount()
        {
            Console.WriteLine("Creating a new account...");

            Console.Write("Enter account number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter initial balance: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());
            Console.Write("Enter annual interest rate (%): ");
            double interestRate = double.Parse(Console.ReadLine());
            Console.Write("Enter account holder's name: ");
            string accountHolderName = Console.ReadLine();
            // Create a new account object with the provided details
            BankAccount newAccount = new BankAccount(accountNumber, initialBalance, interestRate, accountHolderName);
            bank.AddAccount(newAccount); // Add account to bank
            Console.WriteLine("Account created successfully!");

            // After creating the account, display the account menu
            AccountMenu(newAccount);
        }

        // Method to select an existing account
        private void SelectAccount()
        {
            Console.WriteLine("Selecting an existing account...");

            Console.Write("Enter account number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            // Retrieve the account from the bank using the account number
            BankAccount selectedAccount = bank.RetrieveAccount(accountNumber);

            // Check if the account exists
            if (selectedAccount != null)
            {
                // Display account details
                Console.WriteLine($"Account Number: {selectedAccount.AccountNumber}");
                Console.WriteLine($"Account Holder's Name: {selectedAccount.AccountHolderName}");
                Console.WriteLine($"Balance: {selectedAccount.Balance}");

                // After selecting the account, display the account menu
                AccountMenu(selectedAccount);
            }
            else
            {
                Console.WriteLine("Account not found!");
            }
        }
        // Method to handle the account menu operations
        private void AccountMenu(BankAccount account)
        {
            int choice;
            do
            {
                DisplayAccountMenu(); // Display the account menu options to the user
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Check Balance
                        CheckBalance(account);
                        break;
                    case 2:
                        // Deposit
                        Deposit(account);
                        break;
                    case 3:
                        // Withdraw
                        Withdraw(account);
                        break;
                    case 4:
                        // Display Transactions
                        DisplayTransactions(account);
                        break;
                    case 5:
                        // Exit Account
                        Console.WriteLine("Exiting account menu.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 5); // Continue looping until the user chooses to exit the account menu (choice 5)
        }

        // Method to check the balance of the account
        private void CheckBalance(BankAccount account)
        {
            Console.WriteLine($"Current Balance: {account.Balance}");
        }

        // Method to deposit money into the account
        private void Deposit(BankAccount account)
        {
            Console.Write("Enter the amount to deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            account.Deposit(amount);
            Console.WriteLine("Deposit is successful.");
        }

        // Method to withdraw money from the account
        private void Withdraw(BankAccount account)
        {
            Console.Write("Enter the amount to withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            if (account.Withdraw(amount))
            {
                Console.WriteLine("Withdrawal is successful.");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }

        // Method to display the transactions of the account
        private void DisplayTransactions(BankAccount account)
        {
            List<string> transactions = account.GetTransactions();
            if (transactions.Count > 0)
            {
                Console.WriteLine("Transaction History:");
                foreach (string transaction in transactions)
                {
                    Console.WriteLine(transaction);
                }
            }
            else
            {
                Console.WriteLine("No transactions found.");
            }
        }
    }

}
