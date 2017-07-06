using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : playerControlDB
{
    //TargetのTransfrom
    [SerializeField]
    Transform target;

    //男のスピード
    [SerializeField]
    float RunSpeed;

    //原点の座標
    Vector3 TargetPos;

    // Use this for initialization
    void Start()
    {
        
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
            BasicAttack();
            RunSpeed = 0;
        }
    }

    public void SetTarget(Transform obj)
    {
        target = obj;
    }

    //パンチが当たった
    [ContextMenu("HitPunch")]
    public void HitPunch()
    {
        Die();
        Destroy(this.gameObject, 2.5f);
    }
}
