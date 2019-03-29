using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class kamikazeMovement : MonoBehaviour
{
    public int target;
    public float speed;
    private Transform target1;
    private Transform target2;
    private Transform target3;




    void Start()
    {
        target = Random.Range(0, 2);
        target = Random.Range(0, 2);

        try
        {
            target1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
        }
        catch (NullReferenceException ex)
        {
            target = 0;
            target1 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
        }
        
        try
        {
            target2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
        }
        catch (NullReferenceException ex)
        {
            target = 1;
            target2 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
        }

    }

    void Update()
    {
        try
        {
            target3 = GameObject.FindGameObjectWithTag("PlayerGabungan").GetComponent<Transform>();
        }
        catch (NullReferenceException ex)
        {
            
        }

        if (target3 == null)
        {
            if (target == 0)
            {
                if (target1 != null)
                    transform.position = Vector2.MoveTowards(transform.position, target1.position, speed * Time.deltaTime);
            }
            else if (target != 0)
            {
                if (target2 != null)
                    transform.position = Vector2.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);
            }

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target3.position, speed * Time.deltaTime);
        }
    }

}