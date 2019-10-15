using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePickup : MonoBehaviour {
    //This script is applied to the GameObject that we want to be able to be picked up.
    //Stores transform of GameObject that holds item.
    public Transform destinationObj;
    bool pickedUp = false;

    private void OnMouseDown()
    {
        //picks up object when player clicks with mouse
            //Shuts of gravity
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            //Sets the position of object to the position of object holder parented to camera.
            this.transform.position = destinationObj.position;
            //parents the object to ObjHolder
            this.transform.parent = GameObject.Find("ObjHolder").transform;
            //toggles object item condition to be picked up
            pickedUp = true;



    }

    private void OnMouseUp()
    {

            //Unparents picked up Object
            this.transform.parent = null;
            //Turns Gravity back on
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            //Toggles item codition to no longer be picked up.
            pickedUp = false;

    }


}
