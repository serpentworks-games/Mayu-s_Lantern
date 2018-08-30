using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;

[System.Serializable]
public class PlayerData
{
    public int SceneID;
    public float posX, posY, posZ;

    public bool isHidden;
    public bool hasLantern;
    public float health;
    public int numberOfSouls;
}
