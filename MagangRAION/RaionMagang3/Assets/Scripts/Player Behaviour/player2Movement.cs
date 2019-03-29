using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Movement : MonoBehaviour
{
    public float speed;
    public bool animated;
    public Animator animator;
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
        if (Input.GetKey(KeyCode.UpArrow))
            ydir = 1;
        if (Input.GetKey(KeyCode.DownArrow))
            ydir = -1;
        if (Input.GetKey(KeyCode.LeftArrow))
            xdir = -1;
        if (Input.GetKey(KeyCode.RightArrow))
            xdir = 1;

        if (animated)
        {
            if (ydir == 0)
                animator.SetBool("isMovingY", false);
            else
                animator.SetBool("isMovingY", true);
        }

        animator.SetFloat("yDir", ydir);

        transform.Translate(x: Time.deltaTime * speed * xdir * inverter, y: Time.deltaTime * speed * ydir * inverter, z: 0f);


        xdir = 0;
        ydir = 0;
    }
}
