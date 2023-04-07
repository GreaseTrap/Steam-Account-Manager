using Structs;

class Program
{
    static void Main(string[] args) {
        if (!File.Exists(Variables.StoragePath)) {
            StreamWriter Stream = File.CreateText(Variables.StoragePath);
            Stream.Flush();
            Stream.Dispose();
        }
        List<string> DataList = File.ReadAllLines(Variables.StoragePath).ToList();
        foreach (string Data in DataList) {
            string[] Entry = Data.Split(',');
            User NewUser = new User(Entry[0], Entry[1]);
            Variables.Users.Add(NewUser);
        }
        RunGui();
        Console.Read();
    }

    static async void RunGui() {
        using var Gui = new Gui();
        await Gui.Run();
    }
}