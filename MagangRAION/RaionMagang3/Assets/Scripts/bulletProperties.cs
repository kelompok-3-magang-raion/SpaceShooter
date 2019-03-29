using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletProperties : MonoBehaviour
{
    public float bulletSpeed;
    public float damage;

    private void Update()
    {
       
        if(Gabung.powerUp)
            GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * 2, GetComponent<Rigidbody2D>().velocity.y);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var enemyHP = other.GetComponent<enemyHP>();
        if (enemyHP != null)
        {
            enemyHP.takeDamage(damage);
            Destroy(gameObject);
        }

        if (other.tag == "Limit")
        {
            Destroy(gameObject);

        }
    }

}
