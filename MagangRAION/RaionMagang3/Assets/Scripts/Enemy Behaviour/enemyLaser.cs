using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLaser : MonoBehaviour
{
    public float bulletSpeed;
    public int damage;

    

    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player1") || other.tag.Equals("Player2") || other.tag.Equals("PlayerGabungan"))
        {
            var playerHP = other.GetComponent<playerHP>();
            if (playerHP != null)
            {
                playerHP.takeDamage(damage);
            }
            Destroy(gameObject);

        }

        if (other.tag == "Limit")
        {
                Destroy(gameObject);
        }
    }

    
}