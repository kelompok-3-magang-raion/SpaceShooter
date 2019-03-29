using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HPUI : MonoBehaviour
{

    public Image[] imageP1;
    public Image[] imageP2;
    GameObject player1;
    GameObject player2;

    public GameObject HPUI1;
    public GameObject HPUI2;

    public GameObject gameOver;

    private bool lose;

    private void Start()
    {
        if (MultiplayerManagement.multiplayer)
        {
            HPUI2.SetActive(true);
        }
        else
        {
            HPUI2.SetActive(false);
        }

        lose = false;
    }


    void Update()
    {

        if (lose) return;
        
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");


        for (int i = 0; i < 3; i++)
        {
            if (player1 != null && i + 1 > player1.GetComponent<playerHP>().hp)
                imageP1[i].enabled = false;

            if (player2 != null && i + 1 > player2.GetComponent<playerHP>().hp)
                imageP2[i].enabled = false;
        }

        if (player1 != null && player1.GetComponent<playerHP>().hp == 0)
        {
            Destroy(player1);
        }

        if (player2 != null && player2.GetComponent<playerHP>().hp == 0)
        {
            Destroy(player2);
        }

        if (player1 == null && player2 == null && GameObject.FindGameObjectWithTag("PlayerGabungan") == null)
        {
            lose = true;
            StartCoroutine(DelayLose());
        }
    }

    IEnumerator DelayLose()
    {
        yield return  new WaitForSeconds(1);
        gameOver.SetActive(true);
        yield return  new WaitForSeconds(2);
        GameManagement.instance.fade.SetTrigger("Fadeout2");
        yield return  new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
    
}
