using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTransition : MonoBehaviour
{

    public Animator animator;
   
    // Update is called once per frame
    public void transitionFade()
    {
            animator.SetTrigger("Fadeout");
            
    }

    public void creditTrigger()
    {
        animator.SetTrigger("Credit");
    }

}
