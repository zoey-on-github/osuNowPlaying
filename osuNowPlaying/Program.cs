using System.Net.Mime;

namespace osuNowPlaying;
using System.Diagnostics;
using System.Management;
using System.IO;
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
class Program {
    static void Main(string[] args)
    {
        if (!File.Exists("path.txt"))
        {
            FileStream ConfigFile = new FileStream("path.txt", FileMode.CreateNew);
        }
        //var configFile = File.Create("path.txt");
        //configFile.Close();
        string pathToConfigFile = File.ReadAllText("path.txt");
        string oldOsuSong = String.Empty;
        while (true) {
            Process[] osu = Process.GetProcessesByName("osu!");
            foreach (Process process in osu) {
                    string newOsuSong = process.MainWindowTitle.Substring(process.MainWindowTitle.IndexOf("-") + 1);
                if (oldOsuSong != newOsuSong && newOsuSong.Contains("-")) {
                    Console.WriteLine(newOsuSong);
                    File.WriteAllText(pathToConfigFile, newOsuSong);
                    oldOsuSong = newOsuSong;
                }
            }
        }
    }
}
