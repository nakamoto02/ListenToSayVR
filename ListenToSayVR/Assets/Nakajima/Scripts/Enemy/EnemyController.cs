using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Enemy_Master
{
    //TargetのTransfrom
    [SerializeField]
    Transform target;

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

    //原点の座標
    Vector3 TargetPos;

    // Use this for initialization
    void Start()
    {
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
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TargetPos - transform.position), 0.3f);

        //Targetに向かって進む
        transform.position += transform.forward * RunSpeed;

        //ターゲットとの距離を取得
        float dis = Vector3.Distance(transform.position,target.transform.position);
        //近づきすぎたら止める
        if (dis < 2.5f)
        {
            anim.SetTrigger(basicAttack);
            RunSpeed = 0;
        }
    }

    public void SetTarget(Transform obj)
    {
        target = obj;
    }

    public void PunchHit(float HandPower,Rigidbody HitObjRig)
    {
        HitPunch(HandPower,HitObjRig);
        anim.SetTrigger(die);
        Destroy(this.gameObject, 2.5f);
    }
    //パンチが当たった
    //[ContextMenu("HitPunch")]
    //public void HitPunch()
    //{
    //    Die();
    //    Destroy(this.gameObject, 2.5f);
    //}

    public override void HitPunch(float HandPower,Rigidbody HitObjRig)
    {
        MyRig.GetComponent<Rigidbody>();
        MyRig.AddForce(transform.forward * -HandPower);
    }
}
