using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CharacterScreenController : MonoBehaviour
{
    public TextMeshProUGUI characterName;

    // Start is called before the first frame update
    void Start()
    {
        characterName.text = StaticData.SelectedCharacterName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
