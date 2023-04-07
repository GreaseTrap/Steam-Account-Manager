namespace Structs
{
    public static class Variables
    {
        public static List<User> Users = new List<User>();
        public const string StoragePath = @"C:\Data.txt";
        public static int SelectedAccount = 0;

        public static string[] ListUsers() {
            List<string> UserList = new List<string>();
            foreach (User _User in Users) {
                UserList.Add(_User.Username);
            }
            return UserList.ToArray();
        }

        public static string NewUsername = "";
        public static string NewPassword = "";
    }
}