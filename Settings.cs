using System.Text.Json;

namespace JavaStarterCompanion;

public class Settings
{
    private static string _fileName = "JscSettings.json";

    public Settings(string javaPath, string javaArgs, string jarPath, string jarArgs)
    {
        JavaPath = javaPath;
        JavaArgs = javaArgs;
        JarPath = jarPath;
        JarArgs = jarArgs;
    }

    public string JavaPath { get; }
    public string JavaArgs { get; }
    public string JarPath { get; }
    public string JarArgs { get; }

    private static Settings GenerateDefault()
    {
        return new Settings("java", "", "launcher.jar", "");
    }

    public static bool ReleaseDefault()
    {
        if (File.Exists(_fileName)) return false;
        GenerateDefault().SerializeJsonToFile();
        return true;
    }

    public void SerializeJsonToFile()
    {
        var json = JsonSerializer.Serialize(this);
        File.WriteAllText(_fileName, json);
    }

    public static Settings DeserializeJsonFromFile()
    {
        var json = File.ReadAllText(_fileName);
        return JsonSerializer.Deserialize<Settings>(json) ?? throw new InvalidOperationException();
    }
}