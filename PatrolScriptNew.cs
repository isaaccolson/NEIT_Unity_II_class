using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolScriptNew : MonoBehaviour
{
    public NavMeshAgent agent;  // component
    public int destination; // marker index #
    public Transform eye;
    public Transform target;
    public bool canMove = true;

    void Update()
    {
        if (CanSeePlayer() && canMove)
        {

            agent.SetDestination(target.transform.position);
        }
        else
        {
            agent.SetDestination(gameObject.transform.position);
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
            }
            //enemy can see player
            else
            {
                canSee = true;
                Debug.Log("CAN see player");
            }
        }
        return canSee;
    }
}
