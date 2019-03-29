using System;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateInfo" , fileName = "PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    public String namePlayer;
    public Color color;
    public GameObject bullet;
    public float fireRate;

    public string audioName;
}
