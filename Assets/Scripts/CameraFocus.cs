using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraFocus : MonoBehaviour
{
    Vector3 offset;
    float diameter;
    float radius;
    public Vector3 CB_size;
    public GameObject GO_toFocus;

    public Simulator simulator;
    public TMP_Dropdown dropdown;
    string CB_name;

    Transform target;
    public float rotateSpeed;
    public bool orbit;



    void Update()
    {
        setOffset();
        cameraOrbit();

        diameter = GO_toFocus.GetComponentInChildren<CelestialBody>().radius;
        radius = diameter / 2f;
        CB_size = new Vector3(radius, radius, radius);

        this.transform.SetParent(GO_toFocus.transform);
        this.transform.position = GO_toFocus.transform.position + CB_size + offset;
    }

    public void setFocus()
    {
        CB_name = dropdown.options[dropdown.value].text;
        foreach (GameObject a in simulator.celestialBodies)
        {
            if (a.name == CB_name)
            {
                GO_toFocus = a;
            }
        }
    }

    void setOffset()
    {
        if (radius <= 5)
        {
            offset = new Vector3(50, 20, 50);
        }
        else if (radius >= 5 && radius <= 10)
        {
            offset = new Vector3(80, 30, 80);
        }
        else if (radius >= 10 && radius <= 50)
        {
            offset = new Vector3(100, 50, 100);
        }
        else if (radius >= 20)
        {
            offset = new Vector3(1000, 200, 1000);
        }
    }

    void cameraOrbit()
    {
        target = this.gameObject.transform.parent;
        transform.LookAt(target);
        if (orbit)
        {
            transform.RotateAround(target.position, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * rotateSpeed);
        }
    }
}