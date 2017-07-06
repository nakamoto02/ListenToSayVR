using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Player/Hand/HandEffect")]
public class HandEffect : MonoBehaviour
{
    const float WAIT_TIME = 3.0f;

    //Audio
    new AudioSource audio;

    Vector3 punchiVelocity;

	void Start ()
    {
        //Audioの取得
        audio = GetComponent<AudioSource>();
        //削除
        Destroy(this.gameObject, WAIT_TIME);
	}

    public void SetPower(Vector3 velocity)
    {
        punchiVelocity = velocity;
        GetComponent<Rigidbody>().AddForce(punchiVelocity * 5);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Enemy")
        {
            //当たった
            collider.GetComponent<EnemyController>().HitPunch(/*punchiVelocity*/);
            //音
            audio.Play();
            //削除
            Destroy(this.gameObject);
        }
    }
}
