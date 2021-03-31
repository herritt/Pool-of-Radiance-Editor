using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterScreenController : MonoBehaviour
{
    public TextMeshProUGUI characterName;

    // Start is called before the first frame update
    void Start()
    {
        if (StaticData.SelectedCharacterName.Length > 0)
        {
            characterName.text = StaticData.SelectedCharacterName;
        }
        
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
