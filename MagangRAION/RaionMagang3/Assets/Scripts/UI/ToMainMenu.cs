using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        pauseAndResume.GameisPause = false;
    }
}
