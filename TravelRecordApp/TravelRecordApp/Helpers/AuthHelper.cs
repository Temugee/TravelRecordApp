using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRecordApp.Helpers
{
    public interface IAuth
    {
        bool RegisterUser(string email, string password);
        bool LoginUser(string email, string password);
        bool IsAuthenticated();
        string GetCurrentUserId();
    }

    public class Auth
    {
        public Auth() { }
        public static bool RegisterUser(string email, string password)
        {
            return true;
        }
        public static bool LoginUser(string email, string password)
        {
            return true;
        }
        public static bool IsAuthenticated()
        {
            return true;
        }
        public static string GetCurrentUserId()
        {
            return "";
        }
    }
}
