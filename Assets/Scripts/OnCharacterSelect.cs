using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class OnCharacterSelect : MonoBehaviour
{
    public string characterFileName;

    public void OnMouseDown()
    {
        string name = gameObject.transform.GetComponent<TMPro.TextMeshProUGUI>().text;

        if (name.Length > 0)
        {
            StaticData.CharacterFileName = characterFileName;
            SceneManager.LoadScene("CharacterScreen");
            StaticData.SelectedCharacter.Name = name;

        } 
    }
}
