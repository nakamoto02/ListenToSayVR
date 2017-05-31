using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyManager
{
    public static List<GameObject> EnemyList = new List<GameObject>();

    public static void PlayerSpeak(Vector3 playerPos, float range, Color color)
    {
        foreach(GameObject enemy in EnemyList)
        {
            //距離
            float dis = (playerPos - enemy.transform.position).magnitude;

            if (dis <= range)
                enemy.GetComponent<MeshRenderer>().material.color = color;
        }
    }

}
