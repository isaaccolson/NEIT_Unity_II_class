using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 30f;
    private bool changingColor = false;
    private PatrolScriptNew patrolScript;
    private Color originalColor;
    public float invincibilityTime;
    public Color damageColor;

    public void Start()
    {
        //Store Original Color of Enemy
        originalColor = this.GetComponent<Renderer>().material.color;

        //Find Patroll Script
        patrolScript = FindObjectOfType<PatrolScriptNew>();

    }
    public void DamageEnemy(float damage)
    {
        if (!changingColor)
        {

            //start corutine changing color
            StartCoroutine("ChangeColor");

            //reduce health
            health -= damage;

            //check to see if enemy is dead
            if (health <= 0f)
            {
                Dead();
            }

        }
    }

    void Dead()
    {
        //Destroy Enemy
        Destroy(this.gameObject);
    }

    IEnumerator ChangeColor()
    {

        //set this renederer material to damage color
        this.GetComponent<Renderer>().material.color = damageColor;

        //switch changing color bool
        changingColor = true;

        //switch canMove to false

        patrolScript.canMove = false;

        yield return new WaitForSeconds(invincibilityTime);

        //switch back changing color bool
        changingColor = false;

        //switch back canMove
        patrolScript.canMove = true;

        //reset color to original

        this.GetComponent<Renderer>().material.color = originalColor;


    }
}
