using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField]
    private GameObject boar_Prefab, tiger_Prefab;


    public Transform[] boar_SpawnPoints, tiger_SpawnPoints;

    [SerializeField]
    private int boar_Count, tiger_Count;

    private int init_Boar_Count, init_Tiger_Count;

    public float wait_Before_Spawn = 10f;

    public GameObject X;



    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        init_Boar_Count = boar_Count;
        init_Tiger_Count = tiger_Count;

        SpawnEnemies();

        StartCoroutine("CheckToSpawnEnemies");
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void SpawnEnemies()
    {
        SpawnBoars();
        SpawnTigers();
    }

    void SpawnBoars()
    {
        int index = 0;
        for (int i = 0; i < boar_Count; i++)
        {
            if (index >= boar_SpawnPoints.Length)
            {
                index = 0;
            }
            Instantiate(boar_Prefab, boar_SpawnPoints[index].position, Quaternion.identity);
            Vector3 boarPos = new Vector3(boar_Prefab.transform.position.x,
                                            boar_Prefab.transform.position.y + 20f,
                                                boar_Prefab.transform.position.z);
            Instantiate(X, boarPos, X.transform.rotation);
            index++;
        }
        boar_Count = 0;
    }
    void SpawnTigers()
    {
        int index = 0;
        for (int i = 0; i < tiger_Count; i++)
        {
            if (index >= tiger_SpawnPoints.Length)
            {
                index = 0;
            }
            Instantiate(tiger_Prefab, tiger_SpawnPoints[index].position, Quaternion.identity);
            index++;
        }
        tiger_Count = 0;
    }

    IEnumerator CheckToSpawnEnemies()
    {
        yield return new WaitForSeconds(wait_Before_Spawn);

        SpawnEnemies();
    }

    public void EnemyDied(string name)
    {
        if (name == "boar")
        {
            boar_Count++;

            if (boar_Count > init_Boar_Count)
            {
                boar_Count = init_Boar_Count;
            }
        }
        if (name == "tiger")
        {
            tiger_Count++;

            if (tiger_Count > init_Tiger_Count)
            {
                tiger_Count = init_Tiger_Count;
            }
        }
    }


    public void StopSpawning()
    {
        StopCoroutine("CheckToSpawnEnemies");
    }
}
