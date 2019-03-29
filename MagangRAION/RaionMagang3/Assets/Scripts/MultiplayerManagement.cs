using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerManagement : MonoBehaviour
{
    public static MultiplayerManagement instance;

    public Vector2 positionPlayer1;
    public Vector2 positionPlayer2;

    public GameObject player1;
    public GameObject player2;

    public PlayerInfo ver1;
    public PlayerInfo ozh1;

    public static bool multiplayer;

    public static PlayerInfo player1Active;
    public static PlayerInfo player2Active;

    public GameObject joinText;
    public GameObject HPUI2;

    private bool inMoving;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
        if (multiplayer)
        {
            Instantiate(player1,positionPlayer1,Quaternion.identity);
            Instantiate(player2,positionPlayer2,Quaternion.identity);
            joinText.SetActive(false);
        }
        else
        {
            Instantiate(player1, new Vector2(positionPlayer1.x, 0) ,Quaternion.identity);
            joinText.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (multiplayer || GameVariables.transitionStage || GameVariables.inSkill) return;
        if (!inMoving && Input.GetKeyDown(KeyCode.Space))
        {
            player2Active = player1Active == ozh1 ? ver1 : ozh1;
            GameObject player = Instantiate(player2, positionPlayer2, Quaternion.identity);
            GameManagement.instance.CheckingPlayer(player);
            inMoving = true;
            joinText.SetActive(false);
            HPUI2.SetActive(true);
        }
        else if (inMoving)
        {
            MoveIn();
        }
    }

    void MoveIn()
    {
        GameVariables.players[1].transform.position = Vector2.MoveTowards(GameVariables.players[1].transform.position,
            new Vector2(-7, GameVariables.players[1].transform.position.y), 10 * Time.deltaTime);

        if (GameVariables.players[1].transform.position.x == -7)
        {
            GameVariables.players[1].GetComponent<playerBounds>().enabled = true;
            inMoving = false;
            multiplayer = true;
        }
    }

    public void SetText(String text)
    {
        joinText.GetComponent<Text>().text = text;
    }
}
