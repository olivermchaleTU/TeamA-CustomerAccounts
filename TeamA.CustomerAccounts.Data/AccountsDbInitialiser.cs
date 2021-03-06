﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamA.CustomerAccounts.Models;

namespace TeamA.CustomerAccounts.Data
{
    public class AccountsDbInitialiser
    {
        public static async Task SeedTestData(AccountsDb context, IServiceProvider services)
        {
            if (context.CustomerAccounts.Any())
            {
                // db is seeded
                return;
            }

            var accounts = new List<CustomerAccountDto>
            {
                new CustomerAccountDto
                {
                    FirstName = "Oliver",
                    LastName = "McHale",
                    Email = "OliverMchale@TeamA.com",
                    Address = "Teesside University",
                    Postcode = "TS1 OLI",
                    DOB = new DateTime(1998, 6, 24),
                    PhoneNumber = "0772092490201",
                    IsActive = true,
                },
                new CustomerAccountDto
                {
                    FirstName = "Stevie",
                    LastName = "Cartmail",
                    Email = "StevieC@TeamA.com",
                    Address = "Teesside University",
                    Postcode = "TS1 STE",
                    DOB = new DateTime(1998, 6, 24),
                    PhoneNumber = "0772092490201",
                    IsActive = true,
                },
                new CustomerAccountDto
                {
                    FirstName = "Kyle",
                    LastName = "Spence",
                    Email = "KyleS@TeamA.com",
                    Address = "Teesside University",
                    Postcode = "TS1 STE",
                    DOB = new DateTime(1998, 6, 24),
                    PhoneNumber = "0772092490201",
                    IsActive = true,
                },
                new CustomerAccountDto
                {
                    FirstName = "Oliver",
                    LastName = "McBurney",
                    Email = "OliMcB@TeamA.com",
                    Address = "Teesside University",
                    Postcode = "TS1 STE",
                    DOB = new DateTime(1998, 6, 24),
                    PhoneNumber = "0772092490201",
                    IsActive = true,
                },
                new CustomerAccountDto
                {
                    FirstName = "Craig",
                    LastName = "Martin",
                    Email = "CraigyM@TeamA.com",
                    Address = "Teesside University",
                    Postcode = "TS1 STE",
                    DOB = new DateTime(1998, 6, 24),
                    PhoneNumber = "0772092490201",
                    IsActive = true,
                },
            };
            accounts.ForEach(a => context.CustomerAccounts.Add(a));

            await context.SaveChangesAsync();
        }
    }
}
