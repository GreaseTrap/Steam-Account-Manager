using System.Diagnostics;
using Microsoft.Win32;
using ImGuiNET;
using ClickableTransparentOverlay;
using Structs;

public class Gui : Overlay
{
    protected override void Render() {
        ImGui.Begin("Steam Account Manager", ImGuiWindowFlags.NoSavedSettings | ImGuiWindowFlags.NoScrollbar);
        ImGui.Combo("Accounts", ref Variables.SelectedAccount, Variables.ListUsers(), Variables.Users.Count);
        if (ImGui.Button("Login")) {
            foreach (Process Proc in Process.GetProcessesByName("steam")) {
                Proc.Kill();
            }
            ProcessStartInfo StartInfo = new ProcessStartInfo();
            StartInfo.FileName = (string?)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Valve\Steam", "SteamExe", "null");
            StartInfo.Arguments = $" -noreactlogin -login {Variables.Users[Variables.SelectedAccount].Username} {Variables.Users[Variables.SelectedAccount].Password}";
            Process.Start(StartInfo);
        }
        ImGui.Separator();
        ImGui.InputText("Username", ref Variables.NewUsername, 100);
        ImGui.InputText("Password", ref Variables.NewPassword, 100);
        if (ImGui.Button("Add Account")) {
            List<string> DataList = File.ReadAllLines(Variables.StoragePath).ToList();
            User NewUser = new User(Variables.NewUsername, Variables.NewPassword);
            Variables.Users.Add(NewUser);
            DataList.Add($"{NewUser.Username},{NewUser.Password}");
            File.WriteAllLines(Variables.StoragePath, DataList);
        }
        ImGui.End();
    }
}