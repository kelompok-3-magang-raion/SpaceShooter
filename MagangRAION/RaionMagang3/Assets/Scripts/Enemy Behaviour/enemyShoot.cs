using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float timeBtwShots;
    private bool firing;
    public Animator animator;

    void Update()
    {

        if (!firing) return;
        if (timeBtwShots <= 0)
        {     
                Shoot();
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
               animator.SetBool("Shooting", false);

        }

    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        timeBtwShots = fireRate;
         animator.SetBool("Shooting", true);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("ShootPoint")) firing = true;
    }
}
