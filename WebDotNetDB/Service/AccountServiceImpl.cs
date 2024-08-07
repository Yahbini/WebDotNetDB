﻿using WebDotNetDB.Models;

namespace WebDotNetDB.Service;

public class AccountServiceImpl : AccountService
{
    private DatabaseContext dbContext;

    public AccountServiceImpl(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public bool Create(Account account)
    {
        try
        {
            dbContext.Accounts.Add(account);
            return dbContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public Account FindByUsername(string username)
    {
        return dbContext.Accounts.SingleOrDefault(a => a.Username == username);
    }

    public bool Login(string username, string password)
    {
        var account = dbContext.Accounts.SingleOrDefault(a => a.Username == username && a.Status);
        if (account != null)
        {
            return BCrypt.Net.BCrypt.Verify(password, account.Password);
        }

        return false;
    }

    public bool Update(Account account)
    {
        try
        {
            dbContext.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
