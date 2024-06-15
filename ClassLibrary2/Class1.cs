using System;
using System.Collections.Generic;

namespace ATMApplication
{
    // Define the Bank class
    public class BankAccount
    {
        private List<BankAccount> accounts;

        public BankAccount()
        {
            accounts = new List<BankAccount>();
        }

        public void AddAccount(BankAccount account)
        {
            accounts.Add(account);
        }

        public BankAccount RetrieveAccount(int accountNumber)
        {
            return accounts.Find(account => account.AccountNumber == accountNumber);
        }
    }
}
