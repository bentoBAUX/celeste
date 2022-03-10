using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CelestialBody : MonoBehaviour
{
    public float radius = 1f;
    public float spin = 1f;

    private void OnValidate()
    {
        this.transform.localScale = Vector3.one * radius;
    }
    private void Update()
    {
        this.transform.Rotate(0, spin, 0);

    }

}
