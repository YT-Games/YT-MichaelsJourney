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
        
        if (health <= 0)
        {
            PlayerDied();

            is_Dead = true;
        }
    }

    void PlayerDied()
    {
        if (is_Tiger)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;

            enemyController.enabled = false;
            navAgent.enabled = false;
            enemyAnim.enabled = false;

            // StartCoroutine

            // EnemyManager spawn more enemies
        }


        if (is_Boar)
        {
            navAgent.velocity = Vector3.zero;
            navAgent.isStopped = true;
            enemyController.enabled = false;

            enemyAnim.Dead();

            // StartCoroutine

            // EnemyManager spawn more enemies
        }

        if (is_Player)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

            for (int i=0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            // call enemy manager to stop spawning enemies

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
        }

        if (tag == Tags.PLAYER_TAG)
        {
            Invoke("RestartGame", 3f);
        }
        else
        {
            Invoke("TurnOffGameObject", 3f);
        }
    }

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

}
