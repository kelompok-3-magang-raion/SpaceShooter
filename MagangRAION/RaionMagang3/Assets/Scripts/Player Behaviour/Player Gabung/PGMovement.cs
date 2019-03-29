using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGMovement : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private float xdir, ydir;

    void Update()
    {
        if (GameVariables.transitionStage)
        {
            animator.SetFloat("yDir", 0);
            return;
        }
        if (Input.GetKey(KeyCode.W))
            ydir = 1;
        if (Input.GetKey(KeyCode.S))
            ydir = -1;
        if (Input.GetKey(KeyCode.LeftArrow))
            xdir = -1;
        if (Input.GetKey(KeyCode.RightArrow))
            xdir = 1;


        animator.SetFloat("yDir", ydir);

        transform.Translate(x: Time.deltaTime * speed * xdir, y: Time.deltaTime * speed * ydir, z: 0f);

        xdir = 0;
        ydir = 0;
    }
}
