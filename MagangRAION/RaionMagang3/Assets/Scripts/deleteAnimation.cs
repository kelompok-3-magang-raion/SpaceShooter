using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAnimation : MonoBehaviour
{
    void Start()
    {
        Invoke("destroyObject", 0.7f);
    }

    void destroyObject()
    {
        Destroy(gameObject);
    }
}
