using System.IO;

public static class StaticData
{
    private static string selectedCharacterName;
    private static FileInfo file;

    public static FileInfo File { get => file; set => file = value; }
    public static string SelectedCharacterName { get => selectedCharacterName; set => selectedCharacterName = value; }
}
