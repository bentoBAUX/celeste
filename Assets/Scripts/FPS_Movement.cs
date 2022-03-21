using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Movement : MonoBehaviour
{
    CharacterController controller;
    public float speed = 12f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Up Down");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.up * y + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}
