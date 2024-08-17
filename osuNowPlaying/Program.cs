using System.Diagnostics;

public class osuNowPlaying {
    const string OUTPUT_FILE = "output.html";
    const string WAITING_TEXT = "Waiting for next song...";

    public static void Main(string[] args) {
        string lastProcessName = string.Empty;
        string currentProcessName = string.Empty;

        while(true) {
            Process[] processList = Process.GetProcessesByName("osu!");

            if (processList.Length > 0) {
                currentProcessName = processList[0].MainWindowTitle;
                if (currentProcessName != lastProcessName) {
                    string songName = currentProcessName[(currentProcessName.IndexOf('-') + 1)..].Trim();
                    string outputContents = currentProcessName.Contains('-') ? songName : WAITING_TEXT;
                    using StreamWriter sw = new(OUTPUT_FILE);
                    sw.WriteLine("<h1>" + outputContents + "</h1>");
                    Console.Write(outputContents);
                    lastProcessName = currentProcessName;
                }
            } // this could be an else statement to capture errors about osu not being open

            Thread.Sleep(1000);
        }
    }
}
