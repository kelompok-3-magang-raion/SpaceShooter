using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int HP;
    public Vector2 positionMove;
 
    private Color normalColor;
    private Color attacked;

    public float speed;

    private bool toggle;

    public GameObject destroyedAnimation;
    
    public float frequency = 20.0f;  // Speed of sin movement
    public float magnitude = 0.5f;   // Size of sin movement
    private Vector3 axis;
    private Vector3 pos;

    private float timeDefine;

    [SerializeField] private bool meteorit;
    
    void Start()
    {
        normalColor = Color.white;
        attacked = Color.gray;
        
        axis = transform.up; 
    }

    void Update()
    {
        if (!toggle)
        {
            if ((Vector2)transform.position == positionMove)
            {
                toggle = true;
                pos = transform.position;
                StartCoroutine(TakeDamage());
            }
            else transform.position = Vector2.MoveTowards(transform.position, positionMove, speed * Time.deltaTime);
        }
        else
        {
            if (meteorit)
            {
                MoveMeteor();
                return;
            }
            try
            {
                if (gameObject.GetComponent<BossAttackPattern>().manaRecovery || !gameObject.GetComponent<BossAttackPattern>().skillActivate)
                    Movement();
            }
            catch (NullReferenceException ex)
            {
                Movement();
            }
        }
    }

    IEnumerator TakeDamage()
    {
        yield return new WaitForSeconds(1);
        gameObject.AddComponent<enemyHP>().enabled = true;
        
        try { GetComponent<BossAttackPattern>().enabled = true; }
        catch (NullReferenceException ex) {}        
        
        GetComponent<enemyHP>().hp = HP;
        GetComponent<enemyHP>().destroyedAnim = destroyedAnimation;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player1") || other.tag.Equals("Player2"))
        {
            other.GetComponent<playerHP>().takeDamage(other.GetComponent<playerHP>().hp);
        }

        if (other.tag.Equals("Bullet"))
        {
            Destroy(other.gameObject);
            StopCoroutine(blinkDamage());
            StartCoroutine(blinkDamage());
        }
    }

    IEnumerator blinkDamage()
    {
        GetComponent<SpriteRenderer>().color = normalColor;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = attacked;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = normalColor;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = attacked;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = normalColor;
    }

    void Movement()
    {
        timeDefine += Time.deltaTime;
        transform.position = pos + axis * Mathf.Sin(timeDefine * frequency) * magnitude;
    }

    void MoveMeteor()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
