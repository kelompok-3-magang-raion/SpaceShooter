using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class CutSceneManagement : MonoBehaviour
{
    [SerializeField] private Flowchart flow;
    private bool tutorialPlay;

    public static CutSceneManagement cutScene;

    private void Awake()
    {
        if (cutScene == null) cutScene = this;
    }

    public void Tutorial()
    {
        tutorialPlay = PlayerPrefs.GetInt("FirstPlay") == 0;
        try
        {
            flow.SetBooleanVariable("Multiplayer", MultiplayerManagement.multiplayer);
            flow.SetGameObjectVariable("Bullet", MultiplayerManagement.player1Active.bullet);
        } catch (NullReferenceException ex){}

        if (tutorialPlay)
        {
            flow.gameObject.SetActive(true);
            flow.SendFungusMessage("Tutorial");
        }
        else
        {
            flow.gameObject.SetActive(true);
            flow.SendFungusMessage("SkipTutorial");
        }
    }

    public void End()
    {
        flow.gameObject.SetActive(true);
        flow.SendFungusMessage("End");
    }

    public void Next()
    {
        flow.SendFungusMessage("Next");
    }
}
