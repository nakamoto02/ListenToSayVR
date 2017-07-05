using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Player/Hand/PlayerPunchi")]
public class PlayerPunchi : MonoBehaviour
{
    //Contorollerの移動速度の基準値
    const float HAND_SPEED_NORM = 2.0f;

    //Transform
    Transform transformCache;
    //Audio
    new AudioSource audio;
    //Contolloer
    [SerializeField]
    OVRInput.Controller handState;
    //EffectのPrefab
    [SerializeField]
    Rigidbody handEfePre;

    //値
    Vector3 handVelocity = Vector3.zero;
    float handPower;
    bool IsHandEfe = false;

	void Start ()
    {
        //Transformを取得
        transformCache = transform;
        //AudioSourceを取得
        audio = transformCache.GetComponent<AudioSource>();
	}

    void Update()
    {
        HandMoveVelocity();
    }

    void HandMoveVelocity()
    {
        //値の取得
        handVelocity = OVRInput.GetLocalControllerVelocity(handState);
        handPower = handVelocity.magnitude;

        //一定速度以下
        if (IsHandEfe) return;
        if (handPower < HAND_SPEED_NORM) return;

        //手を生成
        Rigidbody handEfe = Instantiate(handEfePre, transformCache.position, transformCache.rotation);
        handEfe.AddForce(handVelocity * 100);

        //インターバル
        StartCoroutine(HandEffectInterval());
    }

    IEnumerator HandEffectInterval()
    {
        IsHandEfe = true;
        yield return new WaitForSeconds(0.5f);
        IsHandEfe = false;
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
        if (handPower < HAND_SPEED_NORM) return;

        //殴った
        EnemyController enemy = coll.GetComponent<EnemyController>();
        enemy.HitPunch();
        coll.GetComponent<Rigidbody>().AddForce(handVelocity * 100);

        //音再生
        audio.Play();
    }
}
