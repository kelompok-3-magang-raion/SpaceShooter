using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGabung : MonoBehaviour
{
    public static bool isGabung = false;
    public static bool tergabung = false;
    GameObject pg;
    Transform target;

    private void Start()
    {
        pg = GameObject.FindGameObjectWithTag("Gabung");
        Vector3 target = pg.transform.position;
        isGabung = false;
        tergabung = false;
    }

    private void Update()
    {
        if (isGabung)
        {
            if (target != null) transform.position = Vector2.MoveTowards(transform.position, target.position , 20 * Time.deltaTime);

            Destroy(gameObject);

        }
    }

    public void Gabung()
    {
       isGabung = true;
    }

}
