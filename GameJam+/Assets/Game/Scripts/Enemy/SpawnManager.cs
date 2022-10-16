using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    private List<GameObject> enemiesOnScreen = new List<GameObject>();
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float respawnTime;
    [SerializeField] private int EnemyNum;
    public int N;
    private float t;
    [SerializeField] private TMP_Text CounterUI;
    private int killCount;

    private void Start()
    {  
        t = 0f;
        killCount = 0;
    }
    private void FixedUpdate()
    {
        N = enemiesOnScreen.Count;
        foreach (var e in enemiesOnScreen)
        {
            if (e == null)
            {
                enemiesOnScreen.Remove(e);
                killCount++;
            }
        }
    }
    private void Update()
    {
        CounterUI.text = killCount.ToString();

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
