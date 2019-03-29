using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashRaion : MonoBehaviour
{
    public Animator splashScreen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(splashRaion());
    }
    
    IEnumerator splashRaion()
    {
        yield return new WaitForSeconds(4);
        splashScreen.SetTrigger("splash");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
