using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchi : MonoBehaviour
{
    AudioSource audio;

	void Start ()
    {
        //AudioSourceを取得
        audio = GetComponent<AudioSource>();
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            //音再生
            audio.Play();
        }
    }
}
