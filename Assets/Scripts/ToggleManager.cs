using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    Transform parentGO;
    GameObject labelGO;
    public string CB_name;
    public Simulator simulator;
    public void getToggleParent()
    {
        parentGO = this.transform.parent;
        labelGO = parentGO.GetChild(1).gameObject;
        CB_name = labelGO.GetComponent<TMP_Text>().text.ToString();
        Debug.Log("Deleting: " + CB_name);

        simulator.planetName = CB_name;
    }
}
