using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{

    public Text[] highscore = new Text[3];
    public Text[] nama = new Text[3];
    public GameObject inputField;
    public InputField input;
    public GameObject buttonUI;


    // Start is called before the first frame update
    void Start()
    {
        
        highscore[0].text = PlayerPrefs.GetInt("Highscore0", 0).ToString();
        highscore[1].text = PlayerPrefs.GetInt("Highscore1", 0).ToString();
        highscore[2].text = PlayerPrefs.GetInt("Highscore2", 0).ToString();
        nama[0].text =  PlayerPrefs.GetString("nama0", "-");
        nama[1].text =  PlayerPrefs.GetString("nama1", "-");
        nama[2].text =  PlayerPrefs.GetString("nama2", "-");
        if (enemyHP.addScore > PlayerPrefs.GetInt("Highscore2", 0))
        {
            buttonUI.SetActive(false);
            inputField.SetActive(true);
        }

    }
    
    // Update is called once per frame
    public void update()
    {
        inputField.SetActive(false);
        
        String s0 = "Highscore" + 0;
        String s1 = "Highscore" + 1;
        String s2 = "Highscore" + 2;
        
        if (enemyHP.addScore > PlayerPrefs.GetInt(s2) && enemyHP.addScore < PlayerPrefs.GetInt(s1))
        {
            inputField.SetActive(true);
            PlayerPrefs.SetInt("Highscore2", enemyHP.addScore);
            
            highscore[0].text = PlayerPrefs.GetInt("Highscore0", 0).ToString();
            highscore[1].text = PlayerPrefs.GetInt("Highscore1", 0).ToString();
            highscore[2].text = PlayerPrefs.GetInt("Highscore2", 0).ToString();
            PlayerPrefs.SetString("nama2", input.text);
            nama[0].text =  PlayerPrefs.GetString("nama0", "-");
            nama[1].text =  PlayerPrefs.GetString("nama1", "-");
            nama[2].text =  PlayerPrefs.GetString("nama2", "-");
        }
        if (enemyHP.addScore > PlayerPrefs.GetInt(s1)&& enemyHP.addScore < PlayerPrefs.GetInt(s0))
        {
            inputField.SetActive(true);
            PlayerPrefs.SetInt("Highscore2", PlayerPrefs.GetInt("Highscore1"));
            PlayerPrefs.SetInt("Highscore1", enemyHP.addScore);
            highscore[0].text = PlayerPrefs.GetInt("Highscore0", 0).ToString();
            highscore[1].text = PlayerPrefs.GetInt("Highscore1", 0).ToString();
            highscore[2].text = PlayerPrefs.GetInt("Highscore2", 0).ToString();
            PlayerPrefs.SetString("nama2", PlayerPrefs.GetString("nama1"));
            PlayerPrefs.SetString("nama1", input.text);
            nama[0].text =  PlayerPrefs.GetString("nama0", "-");
            nama[1].text =  PlayerPrefs.GetString("nama1", "-");
            nama[2].text =  PlayerPrefs.GetString("nama2", "-");
        }
        if(enemyHP.addScore > PlayerPrefs.GetInt(s0))
        {
            inputField.SetActive(true); 
            
            PlayerPrefs.SetInt(s2, PlayerPrefs.GetInt(s1));
            PlayerPrefs.SetInt(s1, PlayerPrefs.GetInt(s0));
            PlayerPrefs.SetInt(s0, enemyHP.addScore);
            highscore[0].text = PlayerPrefs.GetInt(s0, 0).ToString();
            highscore[1].text = PlayerPrefs.GetInt(s1, 0).ToString();
            highscore[2].text = PlayerPrefs.GetInt(s2, 0).ToString();
            PlayerPrefs.SetString("nama2", PlayerPrefs.GetString("nama1"));
            PlayerPrefs.SetString("nama1", PlayerPrefs.GetString("nama0"));
            PlayerPrefs.SetString("nama0", input.text);
            nama[0].text =  PlayerPrefs.GetString("nama0", "-");
            nama[1].text =  PlayerPrefs.GetString("nama1", "-");
            nama[2].text =  PlayerPrefs.GetString("nama2", "-");
        }
        enemyHP.addScore = 0;
    }

    public void resetScore()
    {
        PlayerPrefs.DeleteAll();
        highscore[0].text = PlayerPrefs.GetInt("Highscore0").ToString();
        highscore[1].text = PlayerPrefs.GetInt("Highscore1").ToString();
        highscore[2].text = PlayerPrefs.GetInt("Highscore2").ToString();
        nama[0].text = PlayerPrefs.GetString("nama0", "-");
        nama[1].text = PlayerPrefs.GetString("nama1", "-");
        nama[2].text = PlayerPrefs.GetString("nama2", "-");
        enemyHP.addScore = 0;
    }
    

}
