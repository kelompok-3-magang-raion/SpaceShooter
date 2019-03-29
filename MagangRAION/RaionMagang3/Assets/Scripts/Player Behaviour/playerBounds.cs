using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBounds : MonoBehaviour
{
    private Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        MainCamera = Camera.main;
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    void LateUpdate()
    {
        Vector3 allowedPos = transform.position;
        allowedPos.x = Mathf.Clamp(allowedPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        allowedPos.y = Mathf.Clamp(allowedPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = allowedPos;
    }
}
