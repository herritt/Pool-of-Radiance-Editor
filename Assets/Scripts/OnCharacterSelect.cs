using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnCharacterSelect : MonoBehaviour
{

    public void OnMouseDown()
    {
        Debug.Log("Mouse click");
        string name = gameObject.transform.GetComponent<TMPro.TextMeshProUGUI>().text;
        Debug.Log(name);
    }
}
