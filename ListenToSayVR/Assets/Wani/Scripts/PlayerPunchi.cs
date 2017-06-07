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

    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.tag == "Enemy")
        {
            //当たった
            collider.GetComponent<EnemyController>().HitPunch();

            //音再生
            audio.Play();
        }
    }
}
