using System.IO;
using TMPro;

public static class StaticData
{
    private static string characterFileName;
    private static TMP_Dropdown selectedSavedGame;
    private static CharacterModel selectedCharacter;

    public static string CharacterFileName { get => characterFileName; set => characterFileName = value; }
    public static TMP_Dropdown SelectedSavedGame { get => selectedSavedGame; set => selectedSavedGame = value; }
    public static CharacterModel SelectedCharacter { get => selectedCharacter; set => selectedCharacter = value; }

    public static string FormattedText(string text, char replacmentChar)
    {
        string formattedClass = text;

        formattedClass = formattedClass.Replace('_', replacmentChar);
        formattedClass = formattedClass.Replace("MAGICUSER", "MAGIC-USER");

        return formattedClass;
    }
}


