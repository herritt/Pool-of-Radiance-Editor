using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.IO;

public class SaveGameReader : MonoBehaviour
{
    public TextMeshProUGUI[] characterNameFields;

    private List<FileInfo> saveGameFiles;
    private List<String> characterFileNames;
    private List<String> characterNames;

    private static int CHARACTER_1_OFFSET = 0x320A;
    private static int CHARACTER_2_OFFSET = 0x3233;
    private static int CHARACTER_3_OFFSET = 0x325C;
    private static int CHARACTER_4_OFFSET = 0x3285;
    private static int CHARACTER_5_OFFSET = 0x32AE;
    private static int CHARACTER_6_OFFSET = 0x32D7;

    private int selectedFileIndex;

    private static string CHR_FILE_POST_FIX = ".SAV";
    private static int LENGTH_OF_CHR_FILE_NAME = 8;
    private static int MAX_NUM_CHARACTERS = 6;

    public void DropdownValueChanged(TMP_Dropdown change)
    {
        selectedFileIndex = change.value;
        StaticData.SelectedSavedGame = change;
        ReadSaveGameFile(saveGameFiles[selectedFileIndex]);

    }

    private void ReadSaveGameFile(FileInfo saveGameFile)
    {
        characterNames = new List<String>();
        characterFileNames = new List<String>();
  
        byte[] buffer = File.ReadAllBytes(saveGameFile.FullName);
        string path = saveGameFile.DirectoryName;

        int[] offsets = { CHARACTER_1_OFFSET , CHARACTER_2_OFFSET , CHARACTER_3_OFFSET , CHARACTER_4_OFFSET , CHARACTER_5_OFFSET, CHARACTER_6_OFFSET };

        for (int i = 0; i < offsets.Length; i++)
        {
            if (SaveGameCharacterFileExists(buffer[offsets[i]]))
            {
                string characterFileName = GetCharacterFileNames(buffer, offsets[i], path);
                characterFileNames.Add(characterFileName);
                characterNames.Add(ReadCharacterNameFromFile(characterFileName));
            }  
        }

        UpdatesPanelWithCharacterNames();
    }

    private void UpdatesPanelWithCharacterNames()
    {

        while (characterNames.Count < MAX_NUM_CHARACTERS)
        {
            characterNames.Add("");
        }

        for (int i = 0; i < MAX_NUM_CHARACTERS; i++)
        {
            characterNameFields[i].text = characterNames[i];

            if (characterFileNames.Count > i)
            {
                characterNameFields[i].transform.GetComponent<OnCharacterSelect>().characterFileName = characterFileNames[i];
            }

        }

    }

    private string GetCharacterFileNames(byte[] buffer, int offset, string path)
    {
        string fileName = System.Text.Encoding.UTF8.GetString(buffer, offset, LENGTH_OF_CHR_FILE_NAME);
        string characterFileName = path + "\\" + fileName + CHR_FILE_POST_FIX;
        return characterFileName;
    }

    private string ReadCharacterNameFromFile(string characterFile)
    {
        byte[] buffer = File.ReadAllBytes(characterFile);
        int lengthOfName = buffer[0];
        string name = System.Text.Encoding.UTF8.GetString(buffer, 1, lengthOfName);

        return name;
    }
    
    private bool SaveGameCharacterFileExists(int decValue)
    {
        string hexValue = decValue.ToString("X");

        if (hexValue.Equals("43"))
            return true;

        return false;
    }

    internal void Initialize(List<FileInfo> saveGameFiles)
    {
        this.saveGameFiles = saveGameFiles;
        DropdownValueChanged(StaticData.SelectedSavedGame);

    }
}
