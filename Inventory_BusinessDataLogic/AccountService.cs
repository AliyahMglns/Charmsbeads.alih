using InventoryDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;
using static System.Net.WebRequestMethods;
using System.ComponentModel;

namespace InventoryBusinessDataLogic
{
   
    public class AccountService
    {
        private List<InventoryDataService.InventoryAccount> accounts = new();

        public AccountService()
        {
            accounts.Add(new InventoryAccount
            {
                Number = "000-111-222",
                Pin = "1111",
                Beads = 0,
                Charms = 0
            });
        }

        public bool ValidateAccount(string number, string pin)
        {
            return accounts.Any(a => a.Number == number && a.Pin == pin);
        }

        public InventoryAccount GetAccount(string number)
        {
            return accounts.FirstOrDefault(a => a.Number == number);
        }

        public void UpdateBeads(string number, int beads)
        {
            var acc = GetAccount(number);
            if (acc != null) acc.Beads = beads;
        }

        public void UpdateCharms(string number, int charms)
        {
            var acc = GetAccount(number);
            if (acc != null) acc.Charms = charms;
        }

        // Not implemented yet
        public void UpdateBeads(string loggedInAccount, object value)
        {
            throw new NotImplementedException();
        }
    }
}

