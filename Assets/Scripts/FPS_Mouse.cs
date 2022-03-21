using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FPS_Mouse : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    float xRotation = 0f;
    public Transform cameraHolder;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        this.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        cameraHolder.Rotate(Vector3.up * mouseX);

    }
}
