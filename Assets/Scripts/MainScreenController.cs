using System.Collections.Generic;
using UnityEngine;

using System.IO;
using TMPro;
using UnityEngine.UI;

public class MainScreenController : MonoBehaviour
{
    public TextMeshProUGUI gamePath;
    public GameObject saveGameDropDownObj;
    public string path;
    public string searchString;

    private List<FileInfo> saveGames;
    private DirectoryInfo directoryInfo;
    private TMP_Dropdown saveGameDropDown;
    private SaveGameReader saveGameReader;

    // Start is called before the first frame update
    void Start()
    {
        directoryInfo = new DirectoryInfo(path);
        saveGames = new List<FileInfo>();
        List<string> saveGameLetters = new List<string>();

        CharacterModel model = new CharacterModel();
        StaticData.SelectedCharacter = model;
 
        FileInfo[] fileInfo = directoryInfo.GetFiles();

        foreach (FileInfo file in fileInfo)
        {
            if (file.FullName.Contains(searchString))
            {
                //extract the letter for the saved game
                int indexToStart = file.FullName.IndexOf(searchString) + searchString.Length;
                string saveGameLetter = file.FullName.Substring(indexToStart, 1);

                saveGameLetters.Add(saveGameLetter);
                saveGames.Add(file);
            }
        }

        gamePath.text = path;

        saveGameDropDown = saveGameDropDownObj.GetComponent<TMP_Dropdown>();
        saveGameDropDown.ClearOptions();
        saveGameDropDown.AddOptions(saveGameLetters);

        saveGameReader = GetComponent<SaveGameReader>();
        saveGameReader.Initialize(saveGames);

        saveGameDropDown.value = StaticData.SelectedSavedGame.value;

        
    }

}
