using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour
{

    private EnemyAnimator enemyAnim;
    private NavMeshAgent navAgent;
    private EnemyController enemyController;

    public float health = 100f;

    public bool is_Player, is_Boar, is_Tiger;

    private bool is_Dead;

    void Awake()
    {
        if (is_Boar || is_Tiger)
        {
            enemyAnim = GetComponent<EnemyAnimator>();
            enemyController = GetComponent<EnemyController>();
            navAgent = GetComponent<NavMeshAgent>();

            //get enemy audio
        }
        if (is_Player)
        {

        }
    }

    public void ApplyDamage(float damage)
    {
        if (is_Dead)
        {
            return;
        }
        health -= damage;

        if (is_Player)
        { // show the stats (display the health UI value) 

        }
        if (is_Boar || is_Tiger)
        {
            if (enemyController.Enemy_State == EnemyState.PATROL)
            {
                enemyController.chase_Distance = 50f;
            }
        }
    }
}
