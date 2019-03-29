using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private float xdir, ydir;
    private float inverter = 1;

    void Update()
    {
        if (MovementManagement.invert)
        {
            inverter = -1;
        }
        else
        {
            inverter = 1;
        }

        if (GameVariables.transitionStage)
        {
            animator.SetFloat("yDir", 0);
            return;
        }
        if (Input.GetKey(KeyCode.W))
            ydir = 1;
        if (Input.GetKey(KeyCode.S))
            ydir = -1;
        if (Input.GetKey(KeyCode.A))
            xdir = -1;
        if (Input.GetKey(KeyCode.D))
            xdir = 1;


        animator.SetFloat("yDir", ydir);

        transform.Translate(x: Time.deltaTime * speed * xdir * inverter, y: Time.deltaTime * speed * ydir * inverter, z: 0f);

        xdir = 0;
        ydir = 0;
    }
}
