using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed;
    public bool orbit;
    void Update()
    {
        transform.LookAt(target);
        if (orbit)
        {
            transform.RotateAround(target.position, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * rotateSpeed);
        }
    }
}
