using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float timeBtwShots;

    private string audio = "playerShoot2";

    void Start()
    {
        fireRate = MultiplayerManagement.player2Active.fireRate;
        bullet = MultiplayerManagement.player2Active.bullet;
        gameObject.GetComponent<SpriteRenderer>().color = MultiplayerManagement.player2Active.color;
        audio = MultiplayerManagement.player2Active.audioName;
    }

    void Update()
    {
        if (GameVariables.transitionStage)
        {
            return;
        }

        if (timeBtwShots <= 0)
        {
            if (Input.GetKey(KeyCode.RightShift))
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
