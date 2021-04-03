using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

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

    List<string> races = new List<string>()
    {
        "",
        "Dwarf", "Elf", "Gnome", "Half-Elf",
        "Halfling", "Half-orc", "Human"
    };

    List<string> alignments = new List<string>()
    {
        "Lawful Good", "Lawful Neutral", "Lawful Evil",
        "Neutral good", "True neutral", "Neutral evil",
        "Chaotic good", "Chaotic Neutral", "Chaotic Evil"
    };

    List<string> characterClasses = new List<string>()
    {
        "Cleric",
        "Druid", "Fighter", "Paladin", "Ranger",
        "Magic-User", "Thief", "Monk", "Cleric/Fighter",
        "Cleric/Fighter/Magic-User", "Cleric/Ranger", "Cleric/Magic-User",
        "Cleric/Theif", "Fighter/Magic-User", "Fighter/Theif",
        "Fighter/Magic-User/Thief", "Magic-User/Theif", "Monster"
    };

    // Start is called before the first frame update
    void Start()
    {
        if (StaticData.SelectedCharacterName.Length > 0)
        {
            characterName.text = StaticData.SelectedCharacterName;
        }
        else return;

        InitializeAttributes();
        InitializeMoney();
    }

    void InitializeAttributes()
    {
        byte[] buffer = File.ReadAllBytes(StaticData.CharacterFileName);

        int offset = ATTRIBUTES_OFFSET;
        strength.text = buffer[offset++].ToString();
        intelligence.text = buffer[offset++].ToString();
        wisdom.text = buffer[offset++].ToString();
        dexterity.text = buffer[offset++].ToString();
        constitution.text = buffer[offset++].ToString();
        charisma.text = buffer[offset].ToString();

        int genderByte = buffer[GENDER_OFFSET];
        gender.text = genderByte == 0 ?  "MALE" : "FEMALE";

        int raceByte = buffer[RACE_OFFSET];
        race.text = races[raceByte];

        age.text = buffer[AGE_OFFSET].ToString();

        alignment.text = alignments[buffer[ALIGNMENT_OFFSET]].ToString();

        characterClass.text = characterClasses[buffer[CLASS_OFFSET]];

        string levelString = "";

        for (int i = CLERIC_LEVEL_OFFSET; i <= MONK_LEVEL_OFFSET; i++)
        {
            if (buffer[i] != 0)
            {
                if (levelString.Length != 0)
                {
                    levelString += "/";
                }
                levelString += buffer[i].ToString();
            }
        }

        level.text = levelString;
        experience.text = LittleEndian(buffer, EXP_OFFSET, 3);

    }

    void InitializeMoney()
    {
        byte[] buffer = File.ReadAllBytes(StaticData.CharacterFileName);

        int offset = MONEY_OFFSET;
        copper.text = LittleEndian(buffer, offset, 2);
        silver.text = LittleEndian(buffer, offset += 2, 2);
        electrum.text = LittleEndian(buffer, offset += 2, 2);
        gold.text = LittleEndian(buffer, offset += 2, 2);
        platinum.text = LittleEndian(buffer, offset += 2, 2);
        gems.text = LittleEndian(buffer, offset += 2, 2);
        jewelry.text = LittleEndian(buffer, offset += 2, 2);
    }

    string LittleEndian(byte[] buffer, int offset, int numBytesToRead)
    {
        int i = 1;
        int value = buffer[offset];
   
        while (i < numBytesToRead)
        {
            value = value | (buffer[offset + i] << (8 * i));
            i++;
        }
        //int value = buffer[offset] | (buffer[offset + 1] << 8);
        return value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExit()
    {
        SceneManager.LoadScene("MainScene");
    }
}
