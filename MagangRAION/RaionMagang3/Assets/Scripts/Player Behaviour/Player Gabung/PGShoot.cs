using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float timeBtwShots;
    Vector3 angle;
    public Animator animator;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightShift))
        {
            animator.SetBool("Shooting", true);
        }
        else
        {
            animator.SetBool("Shooting", false);
        }

        if (timeBtwShots <= 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightShift))
            {
                Shoot();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void Shoot()
    {
       /* angle = new Vector3(0, 0, 0);
        float angleb = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg;
        float spread = Random.Range(-50, 50);
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, 0 , angleb + spread)); */
       

        Instantiate(bullet, firePoint.position, firePoint.rotation);
        timeBtwShots = fireRate;
    }
}
