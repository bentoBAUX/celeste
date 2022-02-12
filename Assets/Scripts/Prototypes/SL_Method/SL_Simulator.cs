using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SL_Simulator : MonoBehaviour
{
    SL_CelestialBodies[] bodies;
    static SL_Simulator instance;
    Vector3 testPosition;
    private void Awake()
    {
        testPosition = new Vector3(10, 10, 10);
        bodies = FindObjectsOfType<SL_CelestialBodies>();
        Time.fixedDeltaTime = SL_Universe.physicsTimeStep;
        Debug.Log("Setting fixedDeltaTime to: " + SL_Universe.physicsTimeStep);
    }
    void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            Vector3 acceleration = CalculateAcceleration(bodies[i].Position, bodies[i]);
            bodies[i].UpdateVelocity(acceleration, SL_Universe.physicsTimeStep);
        }

        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(SL_Universe.physicsTimeStep);
        }
    }

    public static Vector3 CalculateAcceleration(Vector3 point, SL_CelestialBodies ignoreBody = null)
    {
        Vector3 acceleration = Vector3.zero;
        foreach (var body in Instance.bodies)
        {
            if (body != ignoreBody)
            {
                float sqrDist = (body.Position - point).sqrMagnitude;
                Vector3 forceDir = (body.Position - point).normalized;
                acceleration = (forceDir * SL_Universe.SL_gravitationalConstant * body.mass) / sqrDist;
            }
        }

        return acceleration;
    }
    public static SL_CelestialBodies[] Bodies
    {
        get
        {
            return Instance.bodies;
        }
    }

    static SL_Simulator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SL_Simulator>();
            }
            return instance;
        }
    }



}
