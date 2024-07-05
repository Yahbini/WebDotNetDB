using WebDotNetDB.Models;

namespace WebDotNetDB.Service;

public interface AccountService
{
    public bool Create(Account account);
    public bool Update(Account account);
    public bool Login(string username, string password);
    public Account FindByUsername(string username);


}
