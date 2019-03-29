using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovementManagement : MonoBehaviour
{
    public static bool invert;
    Scene currentScene;
    string sceneName;

    private void Start()
    {
        invert = false;
    }

    public void Invert()
    {
        invert = true;
    }

    public void UnInvert()
    {
        invert = false;
    }

}
