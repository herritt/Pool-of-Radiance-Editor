using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateLevelsInputFields : MonoBehaviour
{
    public GameObject level2;
    public GameObject level3;

    public void OnClassChange(TMP_Dropdown change)
    {
        string selection = change.options[change.value].text;

        int count = selection.Split('/').Length;

        level3.SetActive(count > 2);
        level2.SetActive(count > 1);
    }

}


