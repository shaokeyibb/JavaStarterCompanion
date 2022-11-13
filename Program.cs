// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using JavaStarterCompanion;

if (Settings.ReleaseDefault())
{
    Console.WriteLine("Settings has been released to Settings.json, please edit it and restart the program.");
    Environment.Exit(0);
}

var settings = Settings.DeserializeJsonFromFile();

if (!File.Exists(settings.JavaPath))
{
    Console.WriteLine("Java path is invalid.");
    Environment.Exit(0);
}

if (!File.Exists(settings.JarPath))
{
    Console.WriteLine("Jar file not found.");
    Environment.Exit(-1);
}

var startInfo =
    new ProcessStartInfo(settings.JavaPath,
        $"{settings.JavaArgs} -jar {settings.JarPath} {settings.JarArgs}")
    {
        CreateNoWindow = true,
        UseShellExecute = false
    };

Process.Start(startInfo);