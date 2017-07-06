using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviour
{

    //TargetのTransfrom
    [SerializeField]
    Transform target;

    //男のアニメーション
    [SerializeField]
    Animation anim;

    //男のスピード
    [SerializeField]
    float RunSpeed;

    //Ray関係
    Ray ray;
    RaycastHit hit;
    [SerializeField]
    float maxRay;

    //原点の座標
    Vector3 TargetPos = Vector3.zero;

    // Use this for initialization
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //向きをTargetに向ける
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TargetPos - transform.position), 0.3f);
        //Targetに向かって進む
        transform.position += transform.forward * RunSpeed;

        float dis = Vector3.Distance(transform.position, target.transform.position);
        if(dis < 2.5f)
        {
            RunSpeed = 0;
        }
    }
}
