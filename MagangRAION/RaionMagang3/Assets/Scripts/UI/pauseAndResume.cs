using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseAndResume : MonoBehaviour
{

    public static bool GameisPause = false;
    public GameObject pauseUI;

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameisPause)
            {
                Pause();
            }
            
        }else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameisPause)
            {
                Resume();
            }
        }
    }

    void Resume()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        GameisPause = false;
    }

    void Pause()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
        GameisPause = true;
    }

}
