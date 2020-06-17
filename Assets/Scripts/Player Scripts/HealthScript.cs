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

    private EnemyAudio enemyAudio;

    private PlayerStats playerStats;

    void Awake()
    {
        if (is_Boar || is_Tiger)
        {
            enemyAnim = GetComponent<EnemyAnimator>();
            enemyController = GetComponent<EnemyController>();
            navAgent = GetComponent<NavMeshAgent>();

            //get enemy audio
            enemyAudio = GetComponentInChildren<EnemyAudio>();
        }
        if (is_Player)
        {
            playerStats = GetComponent<PlayerStats>();
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
            playerStats.DisplayHealthStats(health);

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

    public void RestoreHealth(float HPAmount)
    {
        if (is_Dead)
        {
            return;
        }
        health += HPAmount;

        playerStats.DisplayHealthStats(health);
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
            StartCoroutine(DeadSound());

            // EnemyManager spawn more enemies
            EnemyManager.instance.EnemyDied("tiger");

        }


        if (is_Boar)
        {
            navAgent.velocity = Vector3.zero;
            navAgent.isStopped = true;
            enemyController.enabled = false;

            enemyAnim.Dead();

            // StartCoroutine
            StartCoroutine(DeadSound());

            // EnemyManager spawn more enemies
            EnemyManager.instance.EnemyDied("boar");
        }

        if (is_Player)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

            for (int i=0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            // call enemy manager to stop spawning enemies
            EnemyManager.instance.StopSpawning();

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

    IEnumerator DeadSound()
    {
        yield return new WaitForSeconds(0.3f);
        enemyAudio.PlayDeadSound();

    }

}
