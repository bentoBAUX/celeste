using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocity : MonoBehaviour
{
    Rigidbody rb;
    Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = new Vector3(0, 2, 0);
        rb.velocity = speed;
    }


}
