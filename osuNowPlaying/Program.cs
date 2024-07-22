namespace osuNowPlaying;
using System.Diagnostics;
using System.Management;
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
class Program {
    static void Main(string[] args) {
        string oldOsuSong = String.Empty;
        while (true) {
            Process[] osu = Process.GetProcessesByName("osu!");
            foreach (Process process in osu) {
                    string newOsuSong = process.MainWindowTitle.Substring(process.MainWindowTitle.IndexOf("-") + 1);
                if (oldOsuSong != newOsuSong && newOsuSong.Contains("-")) {
                    Console.WriteLine(newOsuSong);
                    oldOsuSong = newOsuSong;
                }
            }
        }
    }
}
