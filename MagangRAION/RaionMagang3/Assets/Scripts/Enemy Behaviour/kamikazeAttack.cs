using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamikazeAttack : MonoBehaviour
{
 
    public int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        var playerHP = other.GetComponent<playerHP>();
        if (playerHP != null)
        {
            FindObjectOfType<AudioManager>().Play("Destroyed");
            playerHP.takeDamage(damage);
            gameObject.GetComponent<enemyHP>().destroyedAnimation();
            Destroy(gameObject);
        }
    }

}