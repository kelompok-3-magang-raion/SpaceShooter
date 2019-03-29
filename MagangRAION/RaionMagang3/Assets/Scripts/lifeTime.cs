using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeTime : MonoBehaviour
{
 
    void Start()
    {
        Invoke("destroy", 2f);
    }

    // Update is called once per frame
    void destroy()
    {
        Destroy(gameObject);
    }
}
