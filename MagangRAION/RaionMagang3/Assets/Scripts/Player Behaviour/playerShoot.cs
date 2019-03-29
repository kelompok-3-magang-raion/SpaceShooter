using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float timeBtwShots;
    private float orfireRate;
    
    private string audio = "playerShoot1";

    void Start()
    {
        fireRate = MultiplayerManagement.player1Active.fireRate;
        orfireRate = fireRate;
        
        bullet = MultiplayerManagement.player1Active.bullet;
        gameObject.GetComponent<SpriteRenderer>().color = MultiplayerManagement.player1Active.color;
        audio = MultiplayerManagement.player1Active.audioName;
    }
    
    void Update()
    {
        if (Gabung.slowMo)
        {
            fireRate = orfireRate / 3;
        }
        else
        {
            fireRate = orfireRate;
        }

        if (GameVariables.transitionStage)
        {
            return;
        }
        if (timeBtwShots <= 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
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
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        timeBtwShots = fireRate;
        FindObjectOfType<AudioManager>().Play(audio);

    }
}