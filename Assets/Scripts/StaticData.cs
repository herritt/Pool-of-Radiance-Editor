using System.IO;
using TMPro;

public static class StaticData
{
    private static string selectedCharacterName;
    private static string characterFileName;
    private static TMP_Dropdown selectedSavedGame;

    public static string SelectedCharacterName { get => selectedCharacterName; set => selectedCharacterName = value; }
    public static string CharacterFileName { get => characterFileName; set => characterFileName = value; }
    public static TMP_Dropdown SelectedSavedGame { get => selectedSavedGame; set => selectedSavedGame = value; }
}


