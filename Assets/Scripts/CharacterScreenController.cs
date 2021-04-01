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

    private static int ATTRIBUTES_OFFSET = 0x10;
    private static int MONEY_OFFSET = 0x88;

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

    }

    void InitializeMoney()
    {
        byte[] buffer = File.ReadAllBytes(StaticData.CharacterFileName);

        int offset = MONEY_OFFSET;
        copper.text = LittleEndian(buffer, offset);
        silver.text = LittleEndian(buffer, offset += 2);
        electrum.text = LittleEndian(buffer, offset += 2);
        gold.text = LittleEndian(buffer, offset += 2);
        platinum.text = LittleEndian(buffer, offset += 2);
        gems.text = LittleEndian(buffer, offset += 2);
        jewelry.text = LittleEndian(buffer, offset += 2);
    }

    string LittleEndian(byte[] buffer, int offset)
    {
        int value = buffer[offset] | (buffer[offset + 1] << 8);
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
