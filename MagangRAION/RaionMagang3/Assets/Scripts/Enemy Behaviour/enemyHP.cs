using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    public float hp;
    public int plusScore = 1;
    public GameObject destroyedAnim;
    public static bool gaugeFill = true;

    public static int addScore;

    public void takeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            if (gaugeFill == true)
            {
                Gabung.gauge += Gabung.addGauge;
            }
            FindObjectOfType<AudioManager>().Play("Destroyed");

            addScore += plusScore;
            destroyedAnimation();
            Destroy(gameObject);
        }
    }

    public void destroyedAnimation()
    {
        Instantiate(destroyedAnim, gameObject.transform.position, gameObject.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D limit)
    {
        if (limit.tag == "Limit")
        {
            Destroy(gameObject);
        }

    }
}