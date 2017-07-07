using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Player/Hand/HandEffect")]
public class HandEffect : MonoBehaviour
{
    const float WAIT_TIME = 3.0f;

    //Velocity
    Vector3 punchiVelocity;

	void Start ()
    {
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
            //削除
            Destroy(this.gameObject);
        }
    }
}
