using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CelestialBody : MonoBehaviour
{
    public float radius = 1f;
    private void OnValidate()
    {
        this.transform.localScale = Vector3.one * radius;
    }
}
