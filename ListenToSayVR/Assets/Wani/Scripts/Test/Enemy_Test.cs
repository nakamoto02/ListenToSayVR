using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Test : MonoBehaviour
{

	void Start ()
    {
        EnemyManager.EnemyList.Add(this.gameObject);
	}
}
