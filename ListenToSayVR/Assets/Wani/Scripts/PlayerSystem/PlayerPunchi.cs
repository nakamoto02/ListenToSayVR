using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchi : MonoBehaviour
{
    AudioSource audio;

    [SerializeField]
    OVRInput.Controller handState;

    //値
    [SerializeField]
    Vector3 handVelocity = Vector3.zero;
    [SerializeField]
    float handPower;

	void Start ()
    {
        //AudioSourceを取得
        audio = GetComponent<AudioSource>();
	}

    void Update()
    {
        handVelocity = OVRInput.GetLocalControllerVelocity(handState);
        handPower = handVelocity.magnitude;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.tag == "Enemy")
        {
            HitHand(collider);
        }
    }

    void HitHand(Collider coll)
    {
        //一定速度以下
        if (handPower < 2) return;

        //殴った
        EnemyController enemy = coll.GetComponent<EnemyController>();
        enemy.HitPunch();
        coll.GetComponent<Rigidbody>().AddForce(handVelocity * 100);

        //音再生
        audio.Play();
    }
}
