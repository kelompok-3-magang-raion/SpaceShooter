using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPattern : MonoBehaviour
{
    public GameObject[] enemy;
    public Wave[] wave;

    private Queue<Wave> hazard = new Queue<Wave>();

    void Start()
    {
        foreach (Wave w in wave)
        {
            hazard.Enqueue(w);
        }

        StartCoroutine(HazardWave());
    }

    IEnumerator HazardWave()
    {
        Wave currentHazard;
        do
        {
            currentHazard = hazard.Dequeue();

            yield return new WaitForSeconds(currentHazard.waveTime);
            for (int i = 0; i < currentHazard.enemySize; i++)
            {
                StartCoroutine(Spawn(currentHazard, i));
                yield return new WaitForSeconds(currentHazard.enemySpawnDelay);
            }

        } while (hazard.Count != 0);        
        GameManagement.instance.BossStage(true);
    }

    IEnumerator Spawn(Wave currentHazard, int index)
    {
        GameObject spawn = Instantiate(EnemyType(currentHazard),PointSpawnManagement.instance.getPosition(currentHazard.spawnPosition[index]), Quaternion.identity);
        if (!currentHazard.nameWave.Equals("Boss"))
        {
            try
            {
                spawn.GetComponent<kamikazeMovement>().speed = currentHazard.speed[index];
            }
            catch (NullReferenceException ex)
            {
                try
                {
                    spawn.GetComponent<meteorMovement>().xSpeed = currentHazard.speed[index];
                }
                catch (NullReferenceException er)
                { 
                    spawn.GetComponent<EnemyMovement>().speed = currentHazard.speed[index];
                }
            }
        }

        yield return null;
    }

    GameObject EnemyType(Wave currentHazard)
    {
        return (currentHazard.enemyType == Wave.EnemyType.Alpha ? enemy[0] :
            currentHazard.enemyType == Wave.EnemyType.Beta ? enemy[1] : enemy[2]);
    }
    
}

[System.Serializable]
public class Wave
{
    public string nameWave;
    public enum EnemyType { Alpha, Beta, Gamma }
    public EnemyType enemyType;

    [Range(0,100)] public int enemySize;
    public PointSpawnManagement.objectPosition[] spawnPosition;
    [Range(1,20)] public float[] speed;
    
    [Range(0,10)] public float waveTime;
    [Range(0,10)] public float enemySpawnDelay;
    
}