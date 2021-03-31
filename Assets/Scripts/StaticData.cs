using System.IO;

public static class StaticData
{
    private static string selectedCharacterName;
    private static string characterFileName;

    
    public static string SelectedCharacterName { get => selectedCharacterName; set => selectedCharacterName = value; }
    public static string CharacterFileName { get => characterFileName; set => characterFileName = value; }
}
