using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorMovement : MonoBehaviour
{
    public float xSpeed;
    private float yspeed;

    public float upLim = 0.5f;
    public float downLim = -0.5f;

    private void Start()
    {
        yspeed = Random.Range(downLim, upLim);
    }

    void Update()
    {
        transform.Translate(x: -xSpeed * Time.deltaTime, y: yspeed * Time.deltaTime, z: 0);
    }

   
}
