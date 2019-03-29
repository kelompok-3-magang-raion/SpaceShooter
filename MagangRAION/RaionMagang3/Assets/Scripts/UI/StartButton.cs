using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    
    public GameObject credits;
    public GameObject leaderBoard;
    public GameObject bonus;
    public GameObject Multiplayer;
    public GameObject buttonUI;

    public void Start()
    {
        buttonUI.SetActive(true);
    }

    public void StartGame()
    {
        buttonUI.SetActive(false);
        Multiplayer.SetActive(true);
        enemyHP.addScore = 0;

    }

    public void credit()
    {
        buttonUI.SetActive(false);
        credits.SetActive(true);
    }

    public void Leaderboard()
    {
        buttonUI.SetActive(false);
        leaderBoard.SetActive(true);
    }

    public void BonusButton()
    {
        buttonUI.SetActive(false);
        bonus.SetActive(true);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void fadeComplete()
    {
        SceneManager.LoadScene(2);
    }

    public void enterScore()
    {
        buttonUI.SetActive(true);
    }

    public void sound()
    {
        FindObjectOfType<AudioManager>().Play("Button");

    }

}
