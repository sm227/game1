using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public enum ENEMYSTATE
    {
        NONE = -1 ,
        IDLE = 0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD
    }
    public ENEMYSTATE enemyState;

    public float stateTime;
    public float idleStateTime;
    public Transform target;

    public float speed = 2f;
    public float attackRange = 2.5f;
    public float attackStateTime = 1f;

    public NavMeshAgent nvAgent;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        enemyState = ENEMYSTATE.IDLE;
        target = GameObject.Find("Player").transform;
        nvAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case ENEMYSTATE.NONE:
                Debug.Log("아무것도 안함!!!!");
                break;
            case ENEMYSTATE.IDLE:
                nvAgent.speed = 0;
                stateTime += Time.deltaTime;
                if(stateTime > idleStateTime)
                {
                    stateTime = 0;
                    enemyState = ENEMYSTATE.MOVE;
                }
                anim.SetInteger("ENEMYSTATE",0);
                break;
            case ENEMYSTATE.MOVE:
                nvAgent.speed = this.speed;
               
                float distance = Vector3.Distance(target.position, transform.position);
                if(distance < attackRange)
                {
                    stateTime = 0;
                    enemyState = ENEMYSTATE.ATTACK;
                }
                else
                {
                    nvAgent.SetDestination(target.position);
                }
                anim.SetInteger("ENEMYSTATE", 1);
                break;
            case ENEMYSTATE.ATTACK:
                nvAgent.speed = 0;
                stateTime += Time.deltaTime;
                if(stateTime > attackStateTime)
                {
                    stateTime = 0;
                    //플레이어 공격!!!!!
                    Debug.Log("공격!!!!!");
                }
                float dist = Vector3.Distance(target.position, transform.position);
                if (dist > attackRange)
                {
                    enemyState = ENEMYSTATE.MOVE;
                    stateTime = 0;
                }
                break;
            case ENEMYSTATE.DAMAGE:
                break;
            case ENEMYSTATE.DEAD:
                break;
            default:
                break;
        }

    }
}
