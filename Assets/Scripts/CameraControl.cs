using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float movementSpeed = 30f;
    public float rotationSpeed = 2f;
    public float upSpeed = 3f;
    public float downSpeed = 3f;

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
        if (Input.GetKey(KeyCode.Space))
        {
            movement.y = 10f * upSpeed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.LeftControl)) 
        {
            movement.y = -10f * downSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement = movement * 3;
        }
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
