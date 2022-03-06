using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public Vector3 offset;
    float radius;
    public Vector3 CB_size;
    public GameObject GO_toFocus;

    void Start()
    {
        radius = GO_toFocus.GetComponentInChildren<CelestialBody>().radius;
        CB_size = new Vector3(radius, radius, radius);
        this.transform.SetParent(GO_toFocus.transform);
        this.transform.position = GO_toFocus.transform.position + offset + CB_size;
    }

}