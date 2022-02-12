using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class SL_CelestialBodies : MonoBehaviour
{
    public float radius;
    public Vector3 initialVelocity;
    public float surfaceGravity;

    public Vector3 velocity { get; private set; }
    public float mass { get; private set; }
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
        velocity = initialVelocity;
    }

    public void UpdateVelocity(SL_CelestialBodies[] bodies, float timeStep)
    {
        foreach (var body in bodies)
        {
            if (body != this)
            {
                float sqrDist = (body.rb.position - rb.position).sqrMagnitude;
                Vector3 forceDir = (body.rb.position - rb.position).normalized;

                Vector3 acceleration = (forceDir * SL_Universe.SL_gravitationalConstant * body.mass) / sqrDist;
                velocity += acceleration * timeStep;
            }
        }
    }

    public void UpdateVelocity(Vector3 acceleration, float timeStep)
    {
        velocity += acceleration * timeStep;
    }

    public void UpdatePosition(float timeStep)
    {
        rb.MovePosition(rb.position + velocity * timeStep);
    }

    private void OnValidate()
    {
        mass = surfaceGravity * radius * radius / SL_Universe.SL_gravitationalConstant;
        this.transform.localScale = Vector3.one * radius;
    }

    public Rigidbody Rigidbody
    {
        get
        {
            return rb;
        }
    }

    public Vector3 Position
    {
        get
        {
            return rb.position;
        }
    }


}
