using WebDotNetDB.Models;

namespace WebDotNetDB.Service;

public interface AccountService
{
    public bool Create(Account account);
    public bool Login(string username, string password);


}
