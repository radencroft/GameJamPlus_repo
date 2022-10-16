using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnManager : MonoBehaviour
{
    private List<GameObject> enemiesOnScreen = new List<GameObject>();
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float respawnTime;
    [SerializeField] private int EnemyNum;
    public int N;
    private float t;

    private void Start()
    { 
        SpawnEnemy();
        t = 0f;
    }
    private void FixedUpdate()
    {
        N = enemiesOnScreen.Count;
        foreach (var e in enemiesOnScreen)
        {
            if (e == null)
            {
                enemiesOnScreen.Remove(e);
            }
        }
    }
    private void Update()
    {
        if (enemiesOnScreen.Count < EnemyNum)
        {
            t += Time.deltaTime;
            if (t >= respawnTime)
            {
                SpawnEnemy();
                t = 0f;
            }
        }
        else
        {
            t = 0f;
        }
    }  

    private void SpawnEnemy()
    {
        GameObject e = Instantiate(enemy, spawnPos.position, Quaternion.identity);
        e.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
        enemiesOnScreen.Add(e);
    }
}
