using System.Diagnostics;
using System.Configuration;

namespace universal_windows_platform_cs.Core.Services
{
    public class AccountUser
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public static class AuthCoreService
    {
        public static AccountUser GetInfo()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string username = appSettings["username"].ToString();
            string password = appSettings["password"].ToString();
            return new AccountUser() { 
                username = username,
                password = password,
            };
        }

        public static bool LoginByUser(string username, string password)
        {
            AccountUser account = GetInfo();
            if (Equals(account.username, username) && Equals(account.password, password))
            {
                return true;
            }
            return false;
        }
    }
}
