using UnityEngine;

public class PointSpawnManagement : MonoBehaviour
{
    public Transform[] positionSpawn;
    private Vector2[] position;
    public static PointSpawnManagement instance;

    public enum objectPosition
    {
        Position1,
        Position2,
        Position3,
        Position4,
        Position5
    }
    
    void Start()
    {
        if (instance == null) instance = this;
        position = new Vector2[positionSpawn.Length];
        Optimize();
    }

    void Optimize()
    {
        for (int i = 0; i < positionSpawn.Length ; i++)
        {
            position[i] = positionSpawn[i].position;
            Destroy(positionSpawn[i].gameObject);   
        }
    }

    public Vector2 getPosition(objectPosition positionValue)
    {
        switch (positionValue)
        {
            case objectPosition.Position1 :
                return position[0];
            case objectPosition.Position2 :
                return position[1];
            case objectPosition.Position3 :
                return position[2];
            case objectPosition.Position4 :
                return position[3];
            case objectPosition.Position5 :
                return position[4];
        }
        return Vector2.zero;
    }
}
