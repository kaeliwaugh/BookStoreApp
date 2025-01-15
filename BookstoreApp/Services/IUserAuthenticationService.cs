using System.Collections.Generic;

namespace BookstoreApp.Services
{
    public interface SimpleAuthenticationService 
    {
       bool Login(string username, string password);
        void Logout();
        bool IsAuthenticated();

    }
} 