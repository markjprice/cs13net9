using System;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } // "Customer" or "Admin"
}

public class AuthService
{
    public bool Register(string username, string password, string role)
    {
        // Implement registration logic
        throw new NotImplementedException();
    }

    public bool Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public bool IsAuthorized(string username, string role)
    {
        // Implement authorization logic
        throw new NotImplementedException();
    }
}
