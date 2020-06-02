using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private EnemyAnimator enemyAnim;
    private NavMeshAgent navAgent;

    private EnemyState enemyState;

    public float walkSpeed = 0.5f;
    public float runSpeed = 4f;

    public float chase_Distance = 7f;
    private float current_Chase_Distance;
    public float attack_Distance = 1.8f;
    public float chase_After_Attack_Distance = 2f;

    public float patrol_Radius_Min = 20f, patrol_Radius_Max = 60f;
    public float patrol_For_This_Time = 15f;
    private float patrol_Timer;

    public float wait_Before_Attack = 2f;
    private float attack_Timer;

    private Transform target;

    private void Awake()
    {
        enemyAnim = GetComponent<EnemyAnimator>();
        navAgent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }
    void Start()
    {
        enemyState = EnemyState.PATROL;

        patrol_Timer = patrol_For_This_Time;

        attack_Timer = wait_Before_Attack; // when the enemy first gets to the player, attack right away

        current_Chase_Distance = chase_Distance; // memorize the value of chase distance so we can put it back
    }

    void Update()
    {
        if (enemyState == EnemyState.PATROL)
        {
            Patrol();
        }
        if (enemyState == EnemyState.CHASE)
        {
            Chase();
        }
        if (enemyState == EnemyState.ATTACK)
        {
            Attack();
        }
    }

    void Patrol()
    {
        navAgent.isStopped = false; // tell nav agent that he can move
        navAgent.speed = walkSpeed;

        patrol_Timer += Time.deltaTime;

        if (patrol_Timer > patrol_For_This_Time)
        {
            SetNewRandomDestination();

            patrol_Timer = 0f;
        }

        if (navAgent.velocity.sqrMagnitude > 0)
        {
            enemyAnim.Walk(true);
        }
        else
        {
            enemyAnim.Walk(false);
        }
        // tests the distance between the player and the enemy
        if (Vector3.Distance(transform.position, target.position) <= chase_Distance)
        {
            enemyAnim.Walk(false);

            enemyState = EnemyState.CHASE;

            // play spotted audio

        }
    }

    void Chase()
    {
        navAgent.isStopped = false; // enable the agent to move again
        navAgent.speed = runSpeed;

        navAgent.SetDestination(target.position); // set the player's position as the destination

        if (navAgent.velocity.sqrMagnitude > 0)
        {
            enemyAnim.Run(true);
        }
        else
        {
            enemyAnim.Run(false);
        }
        // if the distance between the enemy and the player is less than the attack distance
        if (Vector3.Distance(transform.position, target.position) <= attack_Distance)
        {
            enemyAnim.Run(false);
            enemyAnim.Walk(false);
            enemyState = EnemyState.ATTACK;

            if (chase_Distance != current_Chase_Distance)
            {
                chase_Distance = current_Chase_Distance;
            }
        }
        else if (Vector3.Distance(transform.position, target.position) > chase_Distance)
        { //player run from the enemy
            enemyAnim.Run(false);
            enemyState = EnemyState.PATROL;

            patrol_Timer = patrol_For_This_Time;

            if (chase_Distance != current_Chase_Distance)
            {
                chase_Distance = current_Chase_Distance;
            }

        }
        {

        }
    }

    void Attack()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        attack_Timer += Time.deltaTime;

        if (attack_Timer > wait_Before_Attack)
        {
            enemyAnim.Attack();

            attack_Timer = 0f;

            // play attack sound
        }

        if (Vector3.Distance(transform.position, target.position) > attack_Distance + chase_After_Attack_Distance)
        {
            enemyState = EnemyState.CHASE;
        }
    }

    void SetNewRandomDestination()
    {
        float random_Radius = Random.Range(patrol_Radius_Min, patrol_Radius_Max);

        Vector3 randDir = Random.insideUnitSphere * random_Radius;
        randDir += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDir, out navHit, random_Radius, -1);

        navAgent.SetDestination(navHit.position);
    }

}