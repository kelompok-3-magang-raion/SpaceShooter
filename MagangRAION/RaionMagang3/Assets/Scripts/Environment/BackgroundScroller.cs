using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-30,30)] public float speedScrollScale;

    public static BackgroundScroller instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
