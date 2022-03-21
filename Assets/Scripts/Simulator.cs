using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Simulator : MonoBehaviour
{
    public GameObject[] celestialBodies;
    public float OrbitMultiplier = 1.00f;

    string planetName = null;

    public TMP_InputField TMP_planetName;
    public TMP_Dropdown dropdown;

    [Range(0.0f, 3.0f)]
    public float timeScale;




    void Start()
    {
        celestialBodies = GameObject.FindGameObjectsWithTag("Celestial");
        InitialVelocity();
        createDropDown();
    }

    private void FixedUpdate()
    {
        Gravity();
        planetName = TMP_planetName.text;
        StartCoroutine(updateArray());
    }

    private void Update()
    {

        Time.timeScale = timeScale;
    }
    void createDropDown()
    {
        System.Collections.Generic.List<GameObject> listGO = new System.Collections.Generic.List<GameObject>(celestialBodies);
        List<string> listName = new List<string>();
        foreach (var name in listGO)
        {
            listName.Add(name.name);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(listName);
    }


    IEnumerator updateArray()
    {
        foreach (GameObject a in celestialBodies)
        {
            if (a.name == planetName)
            {
                Debug.Log("Destroying: " + a.name);
                a.gameObject.SetActive(false);
                System.Collections.Generic.List<GameObject> list = new System.Collections.Generic.List<GameObject>(celestialBodies);
                list.Remove(a);
                celestialBodies = list.ToArray();
                yield return null;
            }
            else
            {
                Debug.Log("Planet not found");
                yield return null;
            }
        }
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
