using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System;

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

    public TMP_InputField currentHP;
    public TMP_InputField maxHP;

    private const int IS_OK = 1;
    private const int IS_UNCONSCIOUS = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        SetUIElementsToStaticData();
    }

    public void SetUIElementsToStaticData()
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

        gender.value = (int)StaticData.SelectedCharacter.Gender;
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
        currentHP.text = StaticData.SelectedCharacter.CurrentHitPoints.ToString();
        maxHP.text = StaticData.SelectedCharacter.MaxHitPoints.ToString();

        List<KeyValuePair<CharacterClass, int>> levels = StaticData.SelectedCharacter.Levels;

        level1.text = levels[0].Value.ToString();
        level2.text = levels[1].Value.ToString();
        level3.text = levels[2].Value.ToString();

        
    }

    public void OnExit()
    {
        SceneManager.LoadScene("CharacterScreen");
    }

    public void OnSave()
    {
        //update model
        StaticData.SelectedCharacter.Strength = int.Parse(strength.text);
        StaticData.SelectedCharacter.Intelligence = int.Parse(intelligence.text);
        StaticData.SelectedCharacter.Wisdom = int.Parse(wisdom.text);
        StaticData.SelectedCharacter.Dexterity = int.Parse(dexterity.text);
        StaticData.SelectedCharacter.Constitution = int.Parse(constitution.text);
        StaticData.SelectedCharacter.Charisma = int.Parse(charisma.text);

        StaticData.SelectedCharacter.Jewelry = int.Parse(jewelry.text);
        StaticData.SelectedCharacter.Gems = int.Parse(gems.text);
        StaticData.SelectedCharacter.Platinum = int.Parse(platinum.text);
        StaticData.SelectedCharacter.Gold = int.Parse(gold.text);
        StaticData.SelectedCharacter.Electrum = int.Parse(electrum.text);
        StaticData.SelectedCharacter.Silver = int.Parse(silver.text);
        StaticData.SelectedCharacter.Copper = int.Parse(copper.text);

        StaticData.SelectedCharacter.Gender = (Gender)gender.value;
        StaticData.SelectedCharacter.Race = (Race)race.value;
        StaticData.SelectedCharacter.Alignment = (Alignment)alignment.value;
        StaticData.SelectedCharacter.CharacterClass = (CharacterClass)characterClass.value;
        StaticData.SelectedCharacter.Experience = int.Parse(experience.text);
        StaticData.SelectedCharacter.CurrentHitPoints = int.Parse(currentHP.text);
        StaticData.SelectedCharacter.MaxHitPoints = int.Parse(maxHP.text);


        //save model
        SaveCharacter();

        /*

        List<KeyValuePair<CharacterClass, int>> levels = StaticData.SelectedCharacter.Levels;

        level1.text = levels[0].Value.ToString();
        level2.text = levels[1].Value.ToString();
        level3.text = levels[2].Value.ToString();

        */

    }

    public void SaveCharacter()
    {
        byte[] buffer = File.ReadAllBytes(StaticData.CharacterFileName);

        int offset = Offsets.ATTRIBUTES_OFFSET;
        buffer[offset++] = (byte)StaticData.SelectedCharacter.Strength;
        buffer[offset++] = (byte)StaticData.SelectedCharacter.Intelligence;
        buffer[offset++] = (byte)StaticData.SelectedCharacter.Wisdom;
        buffer[offset++] = (byte)StaticData.SelectedCharacter.Dexterity;
        buffer[offset++] = (byte)StaticData.SelectedCharacter.Constitution;
        buffer[offset++] = (byte)StaticData.SelectedCharacter.Charisma;
        buffer[Offsets.GENDER_OFFSET] = (byte)(StaticData.SelectedCharacter.Gender);
        buffer[Offsets.RACE_OFFSET] = (byte)(StaticData.SelectedCharacter.Race);
        buffer[Offsets.ALIGNMENT_OFFSET] = (byte)(StaticData.SelectedCharacter.Alignment);
        buffer[Offsets.AGE_OFFSET] = (byte)(StaticData.SelectedCharacter.Age);
        buffer[Offsets.CLASS_OFFSET] = (byte)(StaticData.SelectedCharacter.CharacterClass);
        buffer[Offsets.CURRENT_HP_OFFSET] = (byte)(StaticData.SelectedCharacter.CurrentHitPoints);
        buffer[Offsets.MAX_HP_OFFSET] = (byte)(StaticData.SelectedCharacter.MaxHitPoints);

        if (StaticData.SelectedCharacter.CurrentHitPoints > 0)
        {
            buffer[Offsets.CONSCIOUS_OFFSET] = IS_OK;
        }
        else
        {
            buffer[Offsets.CONSCIOUS_OFFSET] = IS_UNCONSCIOUS;
        }

        offset = Offsets.MONEY_OFFSET;

        InsertIntInByteArrayLittleEndian(StaticData.SelectedCharacter.Copper, 
            buffer, offset, 2);
        InsertIntInByteArrayLittleEndian(StaticData.SelectedCharacter.Silver,
            buffer, offset += 2, 2);
        InsertIntInByteArrayLittleEndian(StaticData.SelectedCharacter.Electrum,
            buffer, offset += 2, 2);
        InsertIntInByteArrayLittleEndian(StaticData.SelectedCharacter.Gold,
            buffer, offset += 2, 2);
        InsertIntInByteArrayLittleEndian(StaticData.SelectedCharacter.Platinum,
            buffer, offset += 2, 2);
        InsertIntInByteArrayLittleEndian(StaticData.SelectedCharacter.Gems,
            buffer, offset += 2, 2);
        InsertIntInByteArrayLittleEndian(StaticData.SelectedCharacter.Jewelry,
            buffer, offset += 2, 2);


        File.WriteAllBytes(StaticData.CharacterFileName, buffer);

        /*

        StaticData.SelectedCharacter.Experience = LittleEndian(buffer, Offsets.EXP_OFFSET, 4);
        */
    }

    private void InsertIntInByteArrayLittleEndian
        (int data, byte[] buffer, int offset, int size)
    {
        buffer[offset++] = (byte)data;
        if (size == 1) return;
        buffer[offset++] = (byte)(((uint)data >> 8) & 0xFF);
        if (size == 2) return;
        buffer[offset++] = (byte)(((uint)data >> 16) & 0xFF);
        if (size == 3) return;
        buffer[offset] = (byte)(((uint)data >> 24) & 0xFF);
    }
}
