internal interface IUserAuthenticationService
{
    bool IsAuthenticated();
    bool Login(string username, string password);
    void Logout();
}