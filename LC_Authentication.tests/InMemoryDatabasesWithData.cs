using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LC_Authentication;

namespace LiveChat_Authentication.tests
{
    public class InMemoryDatabasesWithData
    {
        //
        //FakeDatabase
        //
        public static void InMemoryDatabaseWithData(ApplicationDbContext context)
        {
            var accounts = new List<AccountDTO>()
            {
                new AccountDTO { AccountID = 1, Username = "Barry", Email = "Barry@gmail.com", Password = "Barry123"},
                new AccountDTO { AccountID = 2, Username = "Sjaak", Email = "Sjaak@gmail.com", Password = "Sjaak123"},
                new AccountDTO { AccountID = 3, Username = "Gert", Email = "Gert@gmail.com", Password = "Gert123"},
            };
            if (!context.accounts.Any())
            {
                context.accounts.AddRange(accounts);
            };
            context.SaveChanges();
        }
    }
}
