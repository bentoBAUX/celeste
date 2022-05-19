using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlanetLight : MonoBehaviour
{
    public GameObject target;
    private void Update()
    {
        this.transform.LookAt(target.transform);
    }
}
