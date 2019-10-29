using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCamera : MonoBehaviour
{
    public float horizontalSensitivity = 10.0f;
    public float verticalSensitivity = 10.0f;
    private float v;
    private float h;
    private float totalV;
    private float totalH;
    private Quaternion tempRotation;
    public float clampAngle = 70.0f;
    public Transform playerTransform;

    void Start()
    {
        // lock cursor
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        // Read user input
        h = horizontalSensitivity * -(Input.GetAxis("Mouse X"));
        v = verticalSensitivity * Input.GetAxis("Mouse Y");


        // Accumulate total rotation from all input to date
        totalH = totalH -= h;
        totalV = totalV -= v;

        //clamp the camera rotation - limit rollover
        totalV = Mathf.Clamp(totalV, -clampAngle, clampAngle);

        //Rotate player controller to run to look at directin
        playerTransform.rotation = Quaternion.Euler(totalV, totalH, 0.0f);

        // Calculate the single Quaternion rotation necessary to get us here
        tempRotation = Quaternion.Euler(totalV, totalH, 0.0f);

        // Apply that single rotation to the camera (from the origin)
        transform.rotation = tempRotation;

        OutOfLock();

    }
    private void OutOfLock()
    {
        // escape key release of lock
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
