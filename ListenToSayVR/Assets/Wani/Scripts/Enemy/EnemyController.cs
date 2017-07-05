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

    //Ray関係
    Ray ray;
    RaycastHit hit;
    float maxRay = 2.0f;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //向きをTargetに向ける
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);

        //Targetに向かって進む
        transform.position += transform.forward * RunSpeed;

        ray = new Ray(transform.position, transform.forward * 1.5f);

        Debug.DrawRay(transform.position, transform.forward * maxRay, Color.red);

        Physics.Raycast(ray, out hit, maxRay);

        //Rayに触れたら攻撃
        if (hit.collider)
        {
            if (hit.collider.tag == "Player")
            {
                BasicAttack();
                RunSpeed = 0;
            }
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
