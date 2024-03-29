using UnityEngine;
using System.Collections;

// add to menu
// load required component

public class FPSInputController : MonoBehaviour
{

    private PlayerMotor motor;
    float rotationSpeed = 20.0f;
    float rotationSensitivity = 0.1f; // This makes rotationSpeed more managable


    // Use this for initialization
    void Awake()
    {
        //load motor variable with PlayerMotor
        motor = gameObject.GetComponent(typeof(PlayerMotor)) as PlayerMotor;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input vector from keyboard or analog stick
        Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));

        // set up condition of direction vector
        if (directionVector != Vector3.zero)
        {

            // Get the length of the directon vector and then normalize it
            // Dividing by the length is cheaper than normalizing when we already have the length anyway
            float directionLength = directionVector.magnitude;
            directionVector = directionVector / directionLength;

            // Make sure the length is no bigger than 1
            directionLength = Mathf.Min(1, directionLength);


            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            directionLength = directionLength * directionLength;

            // Multiply the normalized direction vector by the modified length
            directionVector = directionVector * directionLength;

        }
        // Apply the direction to the CharacterMotor
        motor.inputMoveDirection = transform.rotation * directionVector;

        // Allow player to Jump
        motor.inputJump = Input.GetButton("Jump");



    }

}
