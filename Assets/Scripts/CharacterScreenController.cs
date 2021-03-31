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


    private static int ATTRIBUTES_OFFSET = 0x10;


    // Start is called before the first frame update
    void Start()
    {
        if (StaticData.SelectedCharacterName.Length > 0)
        {
            characterName.text = StaticData.SelectedCharacterName;
        }
        else return;

        InitializeAttributes();
        
    }

    void InitializeAttributes()
    {
        Debug.Log("StaticData.File.FullName: " + StaticData.CharacterFileName);

        byte[] buffer = File.ReadAllBytes(StaticData.CharacterFileName);

        Debug.Log("Buffer[ATTRIBUTES_OFFSET] " + buffer[ATTRIBUTES_OFFSET]);

        int offset = ATTRIBUTES_OFFSET;
        strength.text = buffer[offset++].ToString();
        intelligence.text = buffer[offset++].ToString();
        wisdom.text = buffer[offset++].ToString();
        dexterity.text = buffer[offset++].ToString();
        constitution.text = buffer[offset++].ToString();
        charisma.text = buffer[offset].ToString();



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
