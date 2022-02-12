using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : MonoBehaviour
{
    GameObject[] celestialBodies;
    public float OrbitMultiplier = 1.00f;

    // Start is called before the first frame update
    void Start()
    {
        celestialBodies = GameObject.FindGameObjectsWithTag("Celestial");
        InitialVelocity();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Gravity();
        Debug.Log(celestialBodies.Length);
    }


    void Gravity()
    {
        foreach (GameObject a in celestialBodies)
        {
            foreach (GameObject b in celestialBodies)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (Universe.gravitationalConstant * (m1 * m2)) / (r * r));

                }
            }
        }
    }

    void InitialVelocity()
    {
        foreach (GameObject a in celestialBodies)
        {
            foreach (GameObject b in celestialBodies)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.transform.LookAt(b.transform);
                    a.GetComponent<Rigidbody>().velocity += (a.transform.right * Mathf.Sqrt((Universe.gravitationalConstant * m2) / r) * OrbitMultiplier);

                }
            }
        }
    }
}
