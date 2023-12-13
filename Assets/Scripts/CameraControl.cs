using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 2f;

    void Update()
    {
        // Move the camera
        MoveCamera();

        // Rotate the camera
        RotateCamera();
    }

    void MoveCamera()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void RotateCamera()
    {
        if (Input.GetMouseButton(1)) // Right mouse button is held down
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Rotate around the Y-axis (left and right)
            transform.Rotate(Vector3.up * mouseX * rotationSpeed);

            // Rotate around the X-axis (up and down), clamped to avoid flipping
            float newRotationX = transform.eulerAngles.x - mouseY * rotationSpeed;
            transform.rotation = Quaternion.Euler(
                Mathf.Clamp(newRotationX, 0f, 90f),
                transform.eulerAngles.y,
                0f
            );
        }
    }
}
