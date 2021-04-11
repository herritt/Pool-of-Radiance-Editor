using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class CharacterScreenController : MonoBehaviour
{
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI strength;
    public TextMeshProUGUI intelligence;
    public TextMeshProUGUI wisdom;
    public TextMeshProUGUI dexterity;
    public TextMeshProUGUI constitution;
    public TextMeshProUGUI charisma;

    public TextMeshProUGUI jewelry;
    public TextMeshProUGUI gems;
    public TextMeshProUGUI platinum;
    public TextMeshProUGUI gold;
    public TextMeshProUGUI electrum;
    public TextMeshProUGUI silver;
    public TextMeshProUGUI copper;

    public TextMeshProUGUI gender;
    public TextMeshProUGUI race;
    public TextMeshProUGUI age;
    public TextMeshProUGUI alignment;
    public TextMeshProUGUI characterClass;
    public TextMeshProUGUI level;
    public TextMeshProUGUI experience;

    private static int ATTRIBUTES_OFFSET = 0x10;
    private static int MONEY_OFFSET = 0x88;
    private static int GENDER_OFFSET = 0x9E;
    private static int RACE_OFFSET = 0x2E;
    private static int AGE_OFFSET = 0x30;
    private static int ALIGNMENT_OFFSET = 0xA0;
    private static int CLASS_OFFSET = 0x2F;
    private static int EXP_OFFSET = 0xAC;

    private static int CLERIC_LEVEL_OFFSET = 0x96;
    private static int DRUID_LEVEL_OFFSET = 0x97;
    private static int FIGHTER_LEVEL_OFFSET = 0x98;
    private static int PALADIN_LEVEL_OFFSET = 0x99;
    private static int RANGER_LEVEL_OFFSET = 0x9A;
    private static int MU_LEVEL_OFFSET = 0x9B;
    private static int THIEF_LEVEL_OFFSET = 0x9C;
    private static int MONK_LEVEL_OFFSET = 0x9D;

    // Start is called before the first frame update
    void Start()
    {
        if (StaticData.SelectedCharacter.Name.Length > 0)
        {
            characterName.text = StaticData.SelectedCharacter.Name;
        }
        else return;

        InitializeAttributes();
        InitializeMoney();

        //TMP_InputField inputField = strength.gameObject.GetComponentInChildren<TMP_InputField>();
        //inputField.transform.gameObject.SetActive(false);

    }

    void InitializeAttributes()
    {
        byte[] buffer = File.ReadAllBytes(StaticData.CharacterFileName);

        int offset = ATTRIBUTES_OFFSET;

        StaticData.SelectedCharacter.Strength = buffer[offset++];
        StaticData.SelectedCharacter.Intelligence = buffer[offset++];
        StaticData.SelectedCharacter.Wisdom = buffer[offset++];
        StaticData.SelectedCharacter.Dexterity = buffer[offset++];
        StaticData.SelectedCharacter.Constitution = buffer[offset++];
        StaticData.SelectedCharacter.Charisma = buffer[offset];
        StaticData.SelectedCharacter.Gender = buffer[GENDER_OFFSET] == 0 ? Gender.MALE : Gender.FEMALE;
        StaticData.SelectedCharacter.Race = (Race)buffer[RACE_OFFSET];
        StaticData.SelectedCharacter.Alignment = (Alignment)buffer[ALIGNMENT_OFFSET];
        StaticData.SelectedCharacter.Age = buffer[AGE_OFFSET];
        StaticData.SelectedCharacter.CharacterClass = (CharacterClass)buffer[CLASS_OFFSET];
        StaticData.SelectedCharacter.Experience = LittleEndian(buffer, EXP_OFFSET, 3);

        strength.text = StaticData.SelectedCharacter.Strength.ToString();
        intelligence.text = StaticData.SelectedCharacter.Intelligence.ToString();
        wisdom.text = StaticData.SelectedCharacter.Wisdom.ToString();
        dexterity.text = StaticData.SelectedCharacter.Dexterity.ToString();
        constitution.text = StaticData.SelectedCharacter.Constitution.ToString();
        charisma.text = StaticData.SelectedCharacter.Charisma.ToString();
        gender.text = StaticData.SelectedCharacter.Gender.ToString();
        race.text = StaticData.FormattedText(StaticData.SelectedCharacter.Race.ToString(), '-');
        alignment.text = StaticData.FormattedText(StaticData.SelectedCharacter.Alignment.ToString(), '-');
        age.text = StaticData.SelectedCharacter.Age.ToString();
        characterClass.text = StaticData.FormattedText(StaticData.SelectedCharacter.CharacterClass.ToString(), '/');
        experience.text = StaticData.SelectedCharacter.Experience.ToString();

        string levelString = "";
        StaticData.SelectedCharacter.Levels = new List<KeyValuePair<CharacterClass, int>>();
        for (int i = CLERIC_LEVEL_OFFSET; i <= MONK_LEVEL_OFFSET; i++)
        {
            if (buffer[i] != 0)
            {
                if (levelString.Length != 0)
                {
                    levelString += "/";
                }
                levelString += buffer[i].ToString();
                StaticData.SelectedCharacter.Levels.Add(new KeyValuePair<CharacterClass, int> ((CharacterClass)i, buffer[i]));

            }
        }

        level.text = levelString;
        

    }

    void InitializeMoney()
    {
        byte[] buffer = File.ReadAllBytes(StaticData.CharacterFileName);

        int offset = MONEY_OFFSET;

        StaticData.SelectedCharacter.Copper = LittleEndian(buffer, offset, 2);
        StaticData.SelectedCharacter.Silver = LittleEndian(buffer, offset += 2, 2);
        StaticData.SelectedCharacter.Electrum = LittleEndian(buffer, offset += 2, 2);
        StaticData.SelectedCharacter.Gold = LittleEndian(buffer, offset += 2, 2);
        StaticData.SelectedCharacter.Platinum = LittleEndian(buffer, offset += 2, 2);
        StaticData.SelectedCharacter.Gems = LittleEndian(buffer, offset += 2, 2);
        StaticData.SelectedCharacter.Jewelry = LittleEndian(buffer, offset += 2, 2);

        copper.text = StaticData.SelectedCharacter.Copper.ToString();
        silver.text = StaticData.SelectedCharacter.Silver.ToString();
        electrum.text = StaticData.SelectedCharacter.Electrum.ToString();
        gold.text = StaticData.SelectedCharacter.Gold.ToString();
        platinum.text = StaticData.SelectedCharacter.Platinum.ToString();
        gems.text = StaticData.SelectedCharacter.Gems.ToString();
        jewelry.text = StaticData.SelectedCharacter.Jewelry.ToString();


    }

    int LittleEndian(byte[] buffer, int offset, int numBytesToRead)
    {
        int i = 1;
        int value = buffer[offset];

        while (i < numBytesToRead)
        {
            value = value | (buffer[offset + i] << (8 * i));
            i++;
        }
        //int value = buffer[offset] | (buffer[offset + 1] << 8);
        return value;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnExit()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnModify()
    {
        SceneManager.LoadScene("ModifyScene");
    }
}
