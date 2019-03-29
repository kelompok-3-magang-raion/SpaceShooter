using UnityEngine;

public class BossAttackPattern : MonoBehaviour
{
    [Range(10,100)] public float skillActive;
    private float baseHP;
    
    private float firing;

    public float manaSize;
    private float mana;

    public float castTime;
    private float casting;

    public float skillAttackSize;

    private Animator anim;

    [SerializeField] private Transform[] position;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject specialBullet;

    [SerializeField] private Attack[] patternAttack;
    private int indexPattern;

    [HideInInspector] public bool skillActivate;
    [HideInInspector] public bool manaRecovery;

    private float delayPattern;

    public GameObject warningSign;

    void Start()
    {
        baseHP = GetComponent<Boss>().HP;
        indexPattern = 0;
        delayPattern = patternAttack[indexPattern].delayPattern;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
        ActivateSkill();
    }

    void Attack()
    {
        if (manaRecovery || !skillActivate)
        {
            if (delayPattern > 0)
            {
                if (firing < 0)
                {
                    firing = patternAttack[indexPattern].fireRate;
                    for (int i = 0; i < patternAttack[indexPattern].type.Length; i++)
                    {
                        int pos = 0;
                        switch (patternAttack[indexPattern].type[i])
                        {
                            case global::Attack.AttacksType.AlphaFire:
                                pos = 0;
                                break;
                            case global::Attack.AttacksType.BetaFire:
                                pos = 1;
                                break;
                            case global::Attack.AttacksType.GammaFire:
                                pos = 2;
                                break;
                        }

                        Instantiate(bullet, position[pos].position, Quaternion.identity);
                    }

                }
                else
                {
                    firing -= Time.deltaTime;
                }

                delayPattern -= Time.deltaTime;
            }
            else
            {
                indexPattern++;
                if (indexPattern == patternAttack.Length) indexPattern = 0;
                delayPattern = patternAttack[indexPattern].delayPattern;
            }
        }
    }
    
    void ActivateSkill()
    {
        if (skillActivate)
        {
            if (mana > manaSize)
            {
                if (casting < 0)
                {
                    mana = 0;
                    casting = castTime;             
                    for (int i = 0; i<skillAttackSize ; i++)
                    {
                        FindObjectOfType<AudioManager>().Play("bigLaser");
                        Instantiate(specialBullet, position[3].position, Quaternion.identity);   
                    }  
                }
                else
                {
                    anim.SetBool("Skill",true);
                    manaRecovery = false;
                    casting -= Time.deltaTime;
     
                    warningSign.SetActive(true);
                    if (casting <= 1)
                        warningSign.SetActive(false);

                }
            }
            else
            {
                if (mana>0.6f) anim.SetBool("Skill",false);
                mana += Time.deltaTime;
                manaRecovery = true;
            }
            return;
        }
        float HPLeft = GetComponent<enemyHP>().hp ;
        if (HPLeft <= baseHP * (skillActive / 100))
        {
            skillActivate = true;
            manaRecovery = true;
            casting = castTime;
            mana = 0;
        }
    }
}

[System.Serializable]
public class Attack
{
    public float fireRate;
    public enum AttacksType { AlphaFire, BetaFire, GammaFire}

    public AttacksType[] type;
    [Range(0,10)] public float delayPattern;
}
