using System.Collections.Generic;
namespace BookstoreApp.Services
{
    public class SimpleUserAuthenticationService : IUserAuthenticationService
    {
        private static bool _isAuthenticated = false;

        private readonly Dictionary<string, string> _validUsers = new()
        {
            { "admin", "password123"}
        };

        public bool Login(string username, string password)
        {
            if(_validUsers.TryGetValue(username, out var storedPassword) && storedPassword == password)
            {
                _isAuthenticated = true;
                return true;
            }
            return false;
        }
        public void Logout()
        {
            _isAuthenticated = false;
        }
        public bool isAuthenticated()
        {
            return _isAuthenticated;
        }
    }

    public interface IUserAuthenticationService
    {
    }
}
