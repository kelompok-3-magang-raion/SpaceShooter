using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gabung : MonoBehaviour
{
    public KeyCode Tombol;
    public GameObject oplayerGabung;
    public GameObject player1;
    public GameObject player2;
    public GameObject flash;

    public Transform spawnPoint;
    public float GaugeLimit;
    public float enemiesToFill = 4f;
    private float showGauge;

    public static float addGauge;
    public static bool powerUp;
    public static float gauge;
    public static bool slowMo;
    bool timeLimit = false;

    private bool gabungan;

    GameObject p1;
    GameObject p2;



    private bool limiter = false;

    void Start()
    {

        addGauge = GaugeLimit / enemiesToFill;
        gauge = 0;   
    }

    void Update()
    {
        if (GameVariables.transitionStage)
        {
            if (Time.timeScale != 1) Time.timeScale = 1;
            return;
        }
        
        p1 = GameObject.FindGameObjectWithTag("Player1");
        p2 = GameObject.FindGameObjectWithTag("Player2");

        if (limiter == false)
        {
            if (gauge <= GaugeLimit)
                enemyHP.gaugeFill = true;
            else
                enemyHP.gaugeFill = false;


        }

        showGauge = gauge;
        if (gauge >= GaugeLimit && !powerUp)
        {
            gauge = GaugeLimit;
            if (Input.GetKey(Tombol) && timeLimit == false)
            {
                GameVariables.inSkill = true;
                powerUp = true;
                if (MultiplayerManagement.multiplayer && p1 != null && p2 != null)
                {
                    Instantiate(flash, spawnPoint.position, spawnPoint.rotation);

                    p1.GetComponent<playerGabung>().Gabung();
                    p2.GetComponent<playerGabung>().Gabung();

                    gabungan = true;

                    Instantiate(oplayerGabung, spawnPoint.position, spawnPoint.rotation);

                    timeLimit = true;
                    limiter = true;
                    enemyHP.gaugeFill = false;
                }
                else
                {
                    if (p1 != null ) p1.GetComponent<playerMovement>().speed *= 3.1f;
                    if (p2 != null ) p2.GetComponent<player2Movement>().speed *= 3.1f;
                    slowMo = true;
                    MultiplayerManagement.instance.SetText("In Skill");

                    Time.timeScale = 0.33f;
                    timeLimit = true;
                    limiter = true;
                    enemyHP.gaugeFill = false;
                }
            }
        }
        else if (timeLimit == true)
        {
            if (gauge > 0)
            {
                if (gabungan) gauge -= Time.deltaTime;
                else gauge -= (Time.deltaTime * 3);
            }

            if (gauge <= 0)
            {
                powerUp = false;
                GameVariables.inSkill = false;
                var pg = GameObject.FindGameObjectWithTag("PlayerGabungan");
                if (MultiplayerManagement.multiplayer && p1 != null && p2!=null || pg != null)
                {

                    timeLimit = false;

                    Instantiate(player1, pg.transform.position, pg.transform.rotation);
                    Instantiate(player2, pg.transform.position, pg.transform.rotation);
                    pg.GetComponent<destroyObject>().destroy();
                    gabungan = false;
                    

                    enemyHP.gaugeFill = true;
                    limiter = false;
                    gauge = 0;
                }
                else
                {
                    timeLimit = false;

                    if (p1 != null ) p1.GetComponent<playerMovement>().speed /= 3.1f;
                    if (p2 != null ) p2.GetComponent<player2Movement>().speed /= 3.1f;
                    slowMo = false;

                    MultiplayerManagement.instance.SetText("Press Space to Join");

                    Time.timeScale = 1f;
                    enemyHP.gaugeFill = true;
                    limiter = false;
                    gauge = 0;
                }
            }
        }

    }
}
