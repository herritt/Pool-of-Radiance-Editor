using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoolOfRadianceFieldValidator : MonoBehaviour
{
    public void OnPlayerStatInputFieldChange()
    {
        TMP_InputField inputField = gameObject.transform.GetComponent<TMP_InputField>();

        //check to make sure it doesn't have any letters
        int value = 3;
        bool result = int.TryParse(inputField.text, out value);

        if (value > 20) value = 20;

        inputField.text = value.ToString();

    }

    public void OnPlayerStatInputEndEdit()
    {
        TMP_InputField inputField = gameObject.transform.GetComponent<TMP_InputField>();

        //check to make sure it doesn't have any letters
        int value = 3;
        bool result = int.TryParse(inputField.text, out value);

        if (value < 3) value = 3;
        if (value > 20) value = 20;

        inputField.text = value.ToString();

    }

    public void OnMoneyInputFieldChange()
    {
        TMP_InputField inputField = gameObject.transform.GetComponent<TMP_InputField>();

        //check to make sure it doesn't have any letters
        int value = 0;
        bool result = int.TryParse(inputField.text, out value);

        if (value > 0xFFFF) value = 0xFFFF;
        if (value < 0) value = 0;

        inputField.text = value.ToString();

    }

    public void OnExperienceInputFieldChange()
    {
        TMP_InputField inputField = gameObject.transform.GetComponent<TMP_InputField>();

        //check to make sure it doesn't have any letters
        int value = 0;
        bool result = int.TryParse(inputField.text, out value);

        if (value < 0) value = 0;

        inputField.text = value.ToString();
    }

    public void OnLevelChange()
    {
        TMP_InputField inputField = gameObject.transform.GetComponent<TMP_InputField>();

        //check to make sure it doesn't have any letters
        int value = 1;
        bool result = int.TryParse(inputField.text, out value);

        if (value < 1) value = 1;
        if (value > 0x7F) value = 0x7F;

        inputField.text = value.ToString();
    }

    public void OnAgeChange()
    {
        TMP_InputField inputField = gameObject.transform.GetComponent<TMP_InputField>();

        //check to make sure it doesn't have any letters
        int value = 16;
        bool result = int.TryParse(inputField.text, out value);

        if (value > 0x7F) value = 0x7F;

        inputField.text = value.ToString();
    }

    public void OnAgeEndEdit()
    {
        TMP_InputField inputField = gameObject.transform.GetComponent<TMP_InputField>();

        //check to make sure it doesn't have any letters
        int value = 16;
        bool result = int.TryParse(inputField.text, out value);

        if (value < 16) value = 16;
        if (value > 0x7F) value = 0x7F;

        inputField.text = value.ToString();
    }
}
