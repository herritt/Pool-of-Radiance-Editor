using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ModifyScreenController : MonoBehaviour
{
    public TextMeshProUGUI characterName;

    public TMP_InputField age;

    public TMP_InputField strength;
    public TMP_InputField intelligence;
    public TMP_InputField wisdom;
    public TMP_InputField dexterity;
    public TMP_InputField constitution;
    public TMP_InputField charisma;

    public TMP_InputField jewelry;
    public TMP_InputField gems;
    public TMP_InputField platinum;
    public TMP_InputField gold;
    public TMP_InputField electrum;
    public TMP_InputField silver;
    public TMP_InputField copper;

    public TMP_InputField experience;

    public TMP_Dropdown gender;
    public TMP_Dropdown race;
    public TMP_Dropdown alignment;
    public TMP_Dropdown characterClass;

    public TMP_InputField level1;
    public TMP_InputField level2;
    public TMP_InputField level3;

    // Start is called before the first frame update
    void Start()
    {
        characterName.text = StaticData.SelectedCharacter.Name;
        age.text = StaticData.SelectedCharacter.Age.ToString();
        strength.text = StaticData.SelectedCharacter.Strength.ToString();
        intelligence.text = StaticData.SelectedCharacter.Intelligence.ToString();
        wisdom.text = StaticData.SelectedCharacter.Wisdom.ToString();
        dexterity.text = StaticData.SelectedCharacter.Dexterity.ToString();
        constitution.text = StaticData.SelectedCharacter.Constitution.ToString();
        charisma.text = StaticData.SelectedCharacter.Charisma.ToString();

        jewelry.text = StaticData.SelectedCharacter.Jewelry.ToString();
        gems.text = StaticData.SelectedCharacter.Gems.ToString();
        platinum.text = StaticData.SelectedCharacter.Platinum.ToString();
        gold.text = StaticData.SelectedCharacter.Gold.ToString();
        electrum.text = StaticData.SelectedCharacter.Electrum.ToString();
        silver.text = StaticData.SelectedCharacter.Silver.ToString();
        copper.text = StaticData.SelectedCharacter.Copper.ToString();

        gender.value = (int) StaticData.SelectedCharacter.Gender;
        race.value = (int)StaticData.SelectedCharacter.Race;
        alignment.value = (int)StaticData.SelectedCharacter.Alignment;
        characterClass.value = (int)StaticData.SelectedCharacter.CharacterClass;

        experience.text = StaticData.SelectedCharacter.Experience.ToString();

        copper.text = StaticData.SelectedCharacter.Copper.ToString();
        silver.text = StaticData.SelectedCharacter.Silver.ToString();
        electrum.text = StaticData.SelectedCharacter.Electrum.ToString();
        gold.text = StaticData.SelectedCharacter.Gold.ToString();
        platinum.text = StaticData.SelectedCharacter.Platinum.ToString();
        gems.text = StaticData.SelectedCharacter.Gems.ToString();
        jewelry.text = StaticData.SelectedCharacter.Jewelry.ToString();

        List<KeyValuePair<CharacterClass, int>> levels = StaticData.SelectedCharacter.Levels;

        level1.text = levels[0].Value.ToString();
        level2.text = levels[1].Value.ToString();
        level3.text = levels[2].Value.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExit()
    {
        SceneManager.LoadScene("CharacterScreen");
    }
}
