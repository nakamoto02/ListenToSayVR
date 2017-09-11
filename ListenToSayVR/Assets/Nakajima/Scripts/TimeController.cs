using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    // 制限時間
    float Timelimit = 30;

    // 時間表示
    public Text TimeLabel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Timelimit -= Time.deltaTime;

        TimeLabel.text = ("Time : " + (int)Timelimit + "秒");
	}
}
