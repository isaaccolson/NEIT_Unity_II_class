using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.AI;



public class PatrolScriptNew : MonoBehaviour

{
    public NavMeshAgent agent;  // component
    private int destination = 0; // make private set to 0
    public Transform eye;
    public Transform target;
    public bool canMove = true;
    public Transform[] destinations;
    private Transform currentDestination;
    public int waitTime;
    private int waitTimeCounter;
     
    //add in patrol stuff
    //destination array, currentDestination, waitTime, waitTimeCounter

    //add start method set currentDestination

     void Start()
    {
        currentDestination = destinations[destination];
    }


    void Update()

    {

        //add in can move up top
        if (canMove)
        {

            if (CanSeePlayer())

            {
                //reset waitTimeCounter to 0
                waitTimeCounter = 0;
                agent.SetDestination(target.transform.position);

            }

            else if (waitTimeCounter < waitTime)//baddie patrols after "looking around"
                                                //add if waitTimeCounter < waitTime
            {
                waitTimeCounter++;
                //add to the waitTimeCounter
                agent.SetDestination(gameObject.transform.position);
                //set animator to false

            }
            else {

                agent.SetDestination(currentDestination.position);

                if (!agent.pathPending && agent.remainingDistance < 1.5f) {

                    destination++;

                    if (destination > destinations.Length - 1) {
                        destination = 0;
                    }

                    currentDestination = destinations[destination];
           

                }

            }
             
        }
    }



    bool CanSeePlayer()

    {

        bool canSee = false;

        Ray ray = new Ray(eye.transform.position, target.transform.position - eye.transform.position);

        RaycastHit hit;



        if (Physics.Raycast(ray, out hit))

        {

            //enemy cannot see player

            if (hit.transform != target)

            {

                canSee = false;

                Debug.Log("Can not see player");
                //set animator walking to false

            }

            //enemy can see player

            else

            {

                canSee = true;

                Debug.Log("CAN see player");
                //set animator walking to true

            }

        }

        return canSee;

    }

}
