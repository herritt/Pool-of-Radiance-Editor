using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OnCharacterSelect : MonoBehaviour
{

    public void OnMouseDown()
    {
        string name = gameObject.transform.GetComponent<TMPro.TextMeshProUGUI>().text;

        if (name.Length > 0)
        {
            StaticData.SelectedCharacterName = name;
            SceneManager.LoadScene("CharacterScreen");

        }

       
    }
}
