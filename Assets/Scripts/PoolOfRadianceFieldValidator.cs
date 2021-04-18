using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoolOfRadianceFieldValidator : MonoBehaviour
{
    private const int PLAYER_STAT_MIN = 3;
    private const int PLAYER_STAT_MAX = 20;

    private const int MONEY_MIN = 0;
    private const int MONEY_MAX = System.UInt16.MaxValue;

    private const int EXP_MIN = 0;
    private const int EXP_MAX = System.UInt16.MaxValue;

    private const int LEVEL_MIN = 1;
    private const int LEVEL_MAX = 0x7F;

    private const int AGE_MIN = 16;
    private const int AGE_MAX = 0x7F;

    private const int CURRENT_HP_MIN = 0;
    private const int MAX_HP_MIN = 1;
    private const int MAX_HP_MAX = 0x7F;


    public TMP_InputField other;

    public void OnPlayerStatInputFieldChange()
    {
        ValidateInputField(PLAYER_STAT_MIN, PLAYER_STAT_MAX, true);

    }
    public void OnPlayerStatInputEndEdit()
    {
        ValidateInputField(PLAYER_STAT_MIN, PLAYER_STAT_MAX, false);

    }

    public void OnMoneyInputFieldChange()
    {
        ValidateInputField(MONEY_MIN, MONEY_MAX, false);
    }

    public void OnExperienceInputFieldChange()
    {
        ValidateInputField(EXP_MIN, EXP_MAX, false);
    }

    public void OnLevelChange()
    {
        ValidateInputField(LEVEL_MIN, LEVEL_MAX, false);

    }

    public void OnAgeChange()
    {
        ValidateInputField(AGE_MIN, AGE_MAX, true);

    }

    public void OnAgeEndEdit()
    {
        ValidateInputField(AGE_MIN, AGE_MAX, false);
    }

    public void OnCurrentHitPointChange()
    {
        int maxHP = 0;
        int.TryParse(other.text, out maxHP);

        ValidateInputField(CURRENT_HP_MIN, maxHP, true);

    }

    public void OnCurrentHitPointEndEdit()
    {
        int maxHP = 0;
        int.TryParse(other.text, out maxHP);

        ValidateInputField(CURRENT_HP_MIN, maxHP, false);
    }

    public void OnMaxHitPointChange()
    {
        ValidateInputField(MAX_HP_MIN, MAX_HP_MAX, true);

    }

    public void OnMaxHitPointEndEdit()
    {
        ValidateInputField(MAX_HP_MIN, MAX_HP_MAX, false);

        TMP_InputField maxHP = gameObject.transform.GetComponent<TMP_InputField>();

        int currentHP, maxHitPoints;
        int.TryParse(other.text, out currentHP);
        int.TryParse(maxHP.text, out maxHitPoints);

        if (currentHP > maxHitPoints)
        {
            other.text = maxHP.text;
        }
    }

    private void ValidateInputField(int minValue, int maxValue, bool isEditing)
    {
        TMP_InputField inputField = gameObject.transform.GetComponent<TMP_InputField>();

        int value = minValue;
        bool result = int.TryParse(inputField.text, out value);

        if (!isEditing)
        {
            if (value < minValue) value = minValue;
        }

        if (value > maxValue) value = maxValue;

        inputField.text = value.ToString();
    }
}
