using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchi : MonoBehaviour
{
    AudioSource audio;

    [SerializeField]
    OVRInput.Controller handState;

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
            collider.GetComponent<Rigidbody>().AddForce(OVRInput.GetLocalControllerVelocity(handState));

            //音再生
            audio.Play();
        }
    }

    float PunchPower()
    {
        //ControllerのVelocity
        Vector3 vel = OVRInput.GetLocalControllerVelocity(handState);

        //Vectorの大きさをfloatに
        float power = Vector3.Distance(Vector3.zero, vel);

        return power;
    }
}
