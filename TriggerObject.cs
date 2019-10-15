using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour {
    //Triggername Serialize Field makes provate variables public
    [SerializeField]
    string objTag;
   private RaycastFromPlayer buttonParams;// CHANGE THIS!!!!

	// Use this for initialization
	void Start () {


        buttonParams = GameObject.FindObjectOfType<RaycastFromPlayer>();

	}

	// Update is called once per frame
	void Update () {

	}
    //Checks to see if obj entered trigger.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == objTag) {
        //    Debug.Log("Entered");
        }
    }
    //Checks to see if obj is still inside the trigger.
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == objTag)
        {
            Debug.Log(other.gameObject.tag);
            //Checks to see if item is placed correctly
            if(other.gameObject.tag == "RedBox")
            {
                buttonParams.RedBlock = true;
                Debug.Log("redbox!");
            }
            if (other.gameObject.tag == "BlueBox")
            {
                buttonParams.BlueBlock = true;
                Debug.Log("bluebox!");
            }
        }
    }
    //Checks to see if obj left the trigger.
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == objTag)
        {
            //Checks to see if item fell off the plate
            Debug.Log("Left");
            if (other.gameObject.tag == "RedBox")
            {
                buttonParams.RedBlock = false;
            }
            if (other.gameObject.tag == "BlueBox")
            {
                buttonParams.BlueBlock = false;
            }
        }
    }
}
