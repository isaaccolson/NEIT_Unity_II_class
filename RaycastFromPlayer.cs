using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//ADDED

public class RaycastFromPlayer : MonoBehaviour
{
    public float raycastdist = 100f;
    public Animator Door;
    public Animator Button;
    public bool RedBlock;
    public bool BlueBlock;
    private bool ButtonPressed = false;

    public Text doorMessage;//ADDED

    // Use this for initialization
    void Start()
    {

        doorMessage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Draws a line to visually debug raycast, this is just a visual representation not actual raycast
        Debug.DrawRay(this.transform.position, this.transform.forward * raycastdist, Color.red);
        //Stores Raycst collision event
        RaycastHit hit;
        //Creates Raycast and checks to see if collision occures.
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, raycastdist))
        {
            //If the Raycast collides with and object of this tag do this.
            if (hit.collider.tag == "DoorButton" && BlueBlock && RedBlock && !ButtonPressed)
            {
                Button.SetBool("Over",true);

                doorMessage.enabled = true;
                if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && !ButtonPressed)
                {
                    Door.SetBool("Open", true);
                    ButtonPressed = true;

                    Button.GetComponentInParent<Renderer>().material.color = Color.green;

                }

            }
            else
            {
                doorMessage.enabled = false;
                Button.SetBool("Over",false);
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {//NOT SET UP YET!
        if (collision.tag == "DoorTrigger")
        {
            Door.SetBool("Open", false);
            Button.SetBool("Pressed", false);
            ButtonPressed = false;


        }
    }
}
