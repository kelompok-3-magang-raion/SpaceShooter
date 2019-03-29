using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fungus;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] private string nextScene;

    public static GameManagement instance;

    public GameObject levelComplete; 

    private bool bossStage;
    private bool endStage;
    private bool openingStage;
    private bool hasClearDialog; 

    private float speed = 10;

    public Animator fade;

    private bool hasNextWave;

    private void Start()
    {
        if (instance == null) instance = this;
        hasClearDialog = false;
        SetUp(false);
    }

    private void Update()
    {        
        if (openingStage && hasClearDialog)
        {
            Opening();
            return;
        }
        if (bossStage) FightingBoss();
        if (endStage && hasClearDialog) Ending();
    }

    void Opening()
    {
        if (GameVariables.players.Count == 2)
        {
            GameVariables.players[0].transform.position = Vector2.MoveTowards(GameVariables.players[0].transform.position,
                new Vector2(-7, GameVariables.players[0].transform.position.y), speed * Time.deltaTime);
            GameVariables.players[1].transform.position = Vector2.MoveTowards(GameVariables.players[1].transform.position,
                new Vector2(-7, GameVariables.players[1].transform.position.y), speed * Time.deltaTime);

            if (GameVariables.players[0].transform.position.x == -7 && GameVariables.players[1].transform.position.x == -7)
            {
                hasClearDialog = false;
                SetUp(true);
            }
        }
        else
        {
            GameVariables.players[0].transform.position = Vector2.MoveTowards(GameVariables.players[0].transform.position,
                new Vector2(-7, GameVariables.players[0].transform.position.y), speed * Time.deltaTime);

            if (GameVariables.players[0].transform.position.x == -7)
            {
                hasClearDialog = false;
                SetUp(true);
            }

        }
    }

    void Ending()
    {
        if (GameVariables.players.Count == 2)
        {
            GameVariables.players[0].transform.position = Vector2.MoveTowards(
                GameVariables.players[0].transform.position,
                new Vector2(13, GameVariables.players[0].transform.position.y), speed * Time.deltaTime);
            GameVariables.players[1].transform.position = Vector2.MoveTowards(
                GameVariables.players[1].transform.position,
                new Vector2(13, GameVariables.players[1].transform.position.y), speed * Time.deltaTime);


            if (GameVariables.players[0].transform.position.x == 13 &&
                GameVariables.players[1].transform.position.x == 13)
            {
                hasClearDialog = false;
                endStage = false;
                StartCoroutine(NextScene());
            }
        }
        else
        {
            GameVariables.players[0].transform.position = Vector2.MoveTowards(
                GameVariables.players[0].transform.position,
                new Vector2(13, GameVariables.players[0].transform.position.y), speed * Time.deltaTime);

            if (GameVariables.players[0].transform.position.x == 13)
            {
                hasClearDialog = false;
                endStage = false;
                StartCoroutine(NextScene());
            }
        }

    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2);
        levelComplete.SetActive(true);
        yield return new WaitForSeconds(2);
        fade.SetTrigger("Fadeout2");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextScene);
    }

    public void BossStage(bool boss)
    {
        bossStage = boss;
    }

    void FightingBoss()
    {
        if (hasNextWave)
        {
            CutSceneManagement.cutScene.Next();
            bossStage = false;
            hasNextWave = false;
            return;
        }
        int size = GameObject.FindGameObjectsWithTag("Boss").Length;
        if (size == 0)
        {
            CheckingPlayer(GameObject.FindGameObjectWithTag("Player1"));
            CheckingPlayer(GameObject.FindGameObjectWithTag("Player2"));
            CheckingPlayer(GameObject.FindGameObjectWithTag("PlayerGabungan"));
            BossStage(false);
            StartCoroutine(EndStage());
        }
    }
    
    IEnumerator EndStage()
    {
        yield return new WaitForSeconds(5);
        if (GameVariables.players.Count == 2)
        {
            try
            {
                GameVariables.players[0].GetComponent<playerBounds>().enabled = false;
                GameVariables.players[1].GetComponent<playerBounds>().enabled = false;
            } catch (MissingReferenceException ex)
            {
                CheckingPlayer(GameObject.FindGameObjectWithTag("Player1"));
                CheckingPlayer(GameObject.FindGameObjectWithTag("Player2"));
                CheckingPlayer(GameObject.FindGameObjectWithTag("PlayerGabungan"));
                GameVariables.players[0].GetComponent<playerBounds>().enabled = false;
            }
        }
        else
        {
            try
            {
                GameVariables.players[0].GetComponent<playerBounds>().enabled = false;
            }
            catch (MissingReferenceException ex)
            {
                CheckingPlayer(GameObject.FindGameObjectWithTag("Player1"));
                CheckingPlayer(GameObject.FindGameObjectWithTag("Player2"));
                CheckingPlayer(GameObject.FindGameObjectWithTag("PlayerGabungan"));
                GameVariables.players[0].GetComponent<playerBounds>().enabled = false;
                GameVariables.players[1].GetComponent<playerBounds>().enabled = false;
            }
        }
        endStage = true;
        GameVariables.transitionStage = true;
        hasClearDialog = false;
        CutSceneManagement.cutScene.End();
    }

    void SetUp(bool set)
    {
        CheckingPlayer(GameObject.FindGameObjectWithTag("Player1"));
        CheckingPlayer(GameObject.FindGameObjectWithTag("Player2"));
        openingStage = !set;
        GameVariables.transitionStage = true;
        if (GameVariables.players.Count == 2)
        {
            GameVariables.players[0].GetComponent<playerBounds>().enabled = set;
            GameVariables.players[1].GetComponent<playerBounds>().enabled = set;
        }
        else
        {
            GameVariables.players[0].GetComponent<playerBounds>().enabled = set;
        }
        
        if (!set) CutSceneManagement.cutScene.Tutorial();
    }

    public void CheckingPlayer(GameObject player)
    {
 
        if (player)
        {
            if (!GameVariables.players.Contains(player))
            {
                GameVariables.players.Add(player);
            }
        }
        
        for (int i = 0 ; i<GameVariables.players.Count ; i++)
        {
            if (!GameVariables.players[i]) GameVariables.players.RemoveAt(i);
        }

    }

    public void Clear()
    {
        hasClearDialog = true;
    }

    public void UnFreezeMovementPlayer()
    {
        GameVariables.transitionStage = false;
    }

    public void HasNext()
    {
        hasNextWave = true;
    }
}
