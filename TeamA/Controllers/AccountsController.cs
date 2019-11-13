﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamA.CustomerAccounts.Data;
using TeamA.CustomerAccounts.Data.Models;

namespace TeamA.Controllers
{
    [ApiController]
    public class AccountsController : Controller
    {

        private readonly AccountsDb _context;

        public AccountsController(AccountsDb context)
        {
            _context = context;
        }

        [HttpGet("api/accounts")]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _context.CustomerAccounts
                                                    .Select(b => new CustomerAccount
                                                    {
                                                        ID = b.ID,
                                                        FirstName = b.FirstName,
                                                        LastName = b.LastName,
                                                        Email = b.Email,
                                                        Address = b.Address,
                                                        Postcode = b.Postcode,
                                                        DOB = b.DOB,
                                                        LoggedOnAt = b.LoggedOnAt,
                                                        PhoneNumber = b.PhoneNumber,
                                                        CanPurchase = b.CanPurchase,
                                                    })
                                                    .ToListAsync();

            return Ok(accounts);
        }

        [HttpGet("api/account")]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            var account = await _context.CustomerAccounts
                                            .Select(b => new CustomerAccount
                                            {
                                                ID = b.ID,
                                                FirstName = b.FirstName,
                                                LastName = b.LastName,
                                                Email = b.Email,
                                                Address = b.Address,
                                                Postcode = b.Postcode,
                                                DOB = b.DOB,
                                                LoggedOnAt = b.LoggedOnAt,
                                                PhoneNumber = b.PhoneNumber,
                                                CanPurchase = b.CanPurchase,
                                            }).Where(a => a.ID == accountId).FirstOrDefaultAsync();

            return Ok(account);
        }

        [HttpPost("api/requestaccountdelete")]
        public async Task<IActionResult> RequestAccountDelete(Guid accountId)
        {
            var account = await _context.CustomerAccounts.Where(a => a.ID == accountId).FirstOrDefaultAsync();

            if (account != null)
            {
                account.IsDeleteRequested = true;

                _context.CustomerAccounts.Update(account);

                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpGet("api/requesteddeletes")]
        public async Task<IActionResult> GetRequestedDeletes()
        {
            var accounts = await _context.CustomerAccounts.Where(a => a.IsDeleteRequested == true).ToListAsync();

            if (accounts != null)
            {
                return Ok(accounts);
            }

            return NotFound();
        }

        [HttpPost("api/updatepurchaseability")]
        public async Task<IActionResult> UpdatePurchaseAbility(Guid accountId, bool canPurchase)
        {
            var account = await _context.CustomerAccounts.Where(a => a.ID == accountId).FirstOrDefaultAsync();

            if (account != null)
            {
                account.CanPurchase = canPurchase;

                _context.CustomerAccounts.Update(account);

                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}