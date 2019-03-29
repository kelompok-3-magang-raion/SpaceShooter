using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x - speed * Time.deltaTime, position.y);

        transform.position = position;

        if(transform.position.x+0.35f < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x)
        {
            DestroyObject(gameObject);
        }

    }
}
