using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoosCharacter : MonoBehaviour
{
    public Image[] character;
    public static GameObject choosenOne;
    public static GameObject choosenTwo;
    public PlayerInfo[] characterPlayer;

    public Animator animator;

    public GameObject join2Player;
    private bool hasStart;
    
    // Start is called before the first frame update
    void Start()
    {
        character[1].color = Color.red;
        MultiplayerManagement.multiplayer = false;
        MultiplayerManagement.player1Active = null;
        MultiplayerManagement.player2Active = null;
    }

// Update is called once per frame
    void Update()
    {
        if (hasStart) return;
        
        if (Input.GetKeyDown(KeyCode.Space) && !MultiplayerManagement.multiplayer)
        {
            FindObjectOfType<AudioManager>().Play("Button");

            if (character[1].color == Color.red)
            {
                character[2].color = Color.red;
            }
            else character[3].color = Color.red;

            join2Player.SetActive(false);
            character[2].gameObject.SetActive(true);
            character[3].gameObject.SetActive(true);
            MultiplayerManagement.multiplayer = true;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (character[1].color == Color.red )
            {
                character[1].color = Color.white;
                character[0].color = Color.red;
                if (MultiplayerManagement.multiplayer)
                {
                    character[3].color = Color.red;
                    character[2].color = Color.white;
                }
            }
        else if (character[0].color == Color.red)
        {
            character[1].color = Color.red;
            character[0].color = Color.white;
            if (MultiplayerManagement.multiplayer)
            {
                 character[3].color = Color.white;
                 character[2].color = Color.red;
            }

        }

    }
        
 }

    public void EnterGame(Button start)
    {
        for (int i = 0; i < character.Length - 2; i++)
        {
            if (character[i].color == Color.red)
            {
                MultiplayerManagement.player1Active = characterPlayer[i];
                if (MultiplayerManagement.multiplayer)
                {
                    MultiplayerManagement.player2Active = characterPlayer[i + 1];
                }
            }
        }
        StartCoroutine(delayIn(start));  
    }

    IEnumerator delayIn(Button start)
    {
        start.interactable = false;
        animator.SetTrigger("Fadeout2");
        hasStart = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

}