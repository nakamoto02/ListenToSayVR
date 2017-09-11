using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    // スコア
    int score;

    // スコア表示
    public Text ScoreLabel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
            ScorePluss();

        ScoreLabel.text = ("Score : " + score + "点");
	}

    public void ScorePluss()
    {
        score++;
    }
}
