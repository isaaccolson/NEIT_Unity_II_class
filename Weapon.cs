using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float weaponDamage = 10f;
    private float weaponRange = 50f;
    public float fireRate = 20;
    public float nextFire = 0f;
    public Camera fpsCamera;
    public ParticleSystem gunFlash;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFire)
        {
            nextFire = Time.time + 1f / fireRate;

            Shoot();
        }
    }

    void Shoot()
    {
        gunFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, weaponRange))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.gameObject.tag == "Enemy")
            {

                hit.transform.GetComponent<Enemy>().DamageEnemy(weaponDamage);

            }
        }
    }
}
