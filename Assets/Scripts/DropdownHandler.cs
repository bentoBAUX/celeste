using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DropdownHandler : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    string CB_name;
    public void setFocus()
    {
        CB_name = dropdown.options[dropdown.value].text;
        //Debug.Log("Focusing: " + CB_name);
    }
}
