using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Player/Hand/HandEffect")]
public class HandEffect : MonoBehaviour
{
    const float WAIT_TIME = 3.0f;

    //Audio
    new AudioSource audio;
    //RigidBody
    Rigidbody efeRigidBody;

	void Start ()
    {
        //Audioの取得
        audio = GetComponent<AudioSource>();
        //RigidBodyの取得
        efeRigidBody = GetComponent<Rigidbody>();
        //削除
        Destroy(this.gameObject, WAIT_TIME);

        Debug.Log("Deta");
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Enemy")
        {
            //当たった
            collider.GetComponent<EnemyController>().HitPunch();
            collider.GetComponent<Rigidbody>().AddForce(efeRigidBody.velocity);

            //音
            audio.Play();
        }
    }
}
