using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Enemy_Master
{
    //ターゲットの座標
    Vector3 target;

    //自身の先端
    [SerializeField]
    Transform TopPoint;

    //自身のRigidbody
    Rigidbody MyRig;

    //ワニのアニメーション
    public Animator anim;
    int basicAttack;
    int getHit;
    int die;
    int run;

    //男のスピード
    [SerializeField]
    float RunSpeed;

    // Use this for initialization
    void Start()
    {
        target = Vector3.zero;
        anim = GetComponent<Animator>();
        basicAttack = Animator.StringToHash("Basic Attack");
        getHit = Animator.StringToHash("Get Hit");
        die = Animator.StringToHash("Die");
        run = Animator.StringToHash("Run");
    }

    // Update is called once per frame
    void Update()
    {

        //向きをTargetに向ける
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target - transform.position), 0.3f);

        //Targetに向かって進む
        transform.position += transform.forward * RunSpeed;

        //ターゲットとの距離を取得
        float dis = Vector3.Distance(TopPoint.transform.position,target);
        //近づきすぎたら止める
        if (dis < 2.5f)
        {
            anim.SetTrigger(basicAttack);
            RunSpeed = 0;
        }
    }

    public void SetTarget(Vector3 obj)
    {
        target = obj;
    }


    public override void HitPunch(Vector3 HandPower)
    {
        MyRig.GetComponent<Rigidbody>().AddForce(HandPower * 5);
        anim.SetTrigger(die);
        Destroy(this.gameObject, 2.5f);
    }
}
