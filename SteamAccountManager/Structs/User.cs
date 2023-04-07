namespace Structs
{
    public struct User
    {
        public User(string User, string Pass) {
            Username = User;
            Password = Pass;
        }
        
        public string Username { get; }
        public string Password { get; }
    }
}