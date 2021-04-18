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
    public TextMeshProUGUI currentHitPoints;
    public TextMeshProUGUI maxHitPoints;


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

        int offset = Offsets.ATTRIBUTES_OFFSET;

        StaticData.SelectedCharacter.Strength = buffer[offset++];
        StaticData.SelectedCharacter.Intelligence = buffer[offset++];
        StaticData.SelectedCharacter.Wisdom = buffer[offset++];
        StaticData.SelectedCharacter.Dexterity = buffer[offset++];
        StaticData.SelectedCharacter.Constitution = buffer[offset++];
        StaticData.SelectedCharacter.Charisma = buffer[offset];
        StaticData.SelectedCharacter.Gender = buffer[Offsets.GENDER_OFFSET] == 0 ? Gender.MALE : Gender.FEMALE;
        StaticData.SelectedCharacter.Race = (Race)buffer[Offsets.RACE_OFFSET];
        StaticData.SelectedCharacter.Alignment = (Alignment)buffer[Offsets.ALIGNMENT_OFFSET];
        StaticData.SelectedCharacter.Age = buffer[Offsets.AGE_OFFSET];
        StaticData.SelectedCharacter.CharacterClass = (CharacterClass)buffer[Offsets.CLASS_OFFSET];
        StaticData.SelectedCharacter.Experience = LittleEndian(buffer, Offsets.EXP_OFFSET, 4);
        StaticData.SelectedCharacter.CurrentHitPoints = buffer[Offsets.CURRENT_HP_OFFSET];
        StaticData.SelectedCharacter.MaxHitPoints = buffer[Offsets.MAX_HP_OFFSET];

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
        currentHitPoints.text = StaticData.SelectedCharacter.CurrentHitPoints.ToString();
        maxHitPoints.text = StaticData.SelectedCharacter.MaxHitPoints.ToString();

        if (StaticData.SelectedCharacter.CurrentHitPoints < StaticData.SelectedCharacter.MaxHitPoints)
        {
            currentHitPoints.color = Color.yellow;
        }

        if (StaticData.SelectedCharacter.CurrentHitPoints <= 0)
        {
            characterName.color = new Color(1, 85.0f / 255, 85.0f / 255);
        }

        string levelString = "";
        StaticData.SelectedCharacter.Levels = new List<KeyValuePair<CharacterClass, int>>();
        for (int i = Offsets.CLERIC_LEVEL_OFFSET; i <= Offsets.MONK_LEVEL_OFFSET; i++)
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

        int offset = Offsets.MONEY_OFFSET;

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
