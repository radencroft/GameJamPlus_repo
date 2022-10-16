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
    [SerializeField] private TMP_Text AgeCounter;
    [SerializeField] private TMP_Text YearCounter;
    [SerializeField] private int startYear;
    [SerializeField] private int gapBtwYears;
    private int year;
    private int killCount;

    private void Start()
    {  
        t = 0f;
        killCount = 0;
        year = startYear;
    }
    private void FixedUpdate()
    {
        N = enemiesOnScreen.Count;
        foreach (var e in enemiesOnScreen)
        {
            if (e == null)
            {
                enemiesOnScreen.Remove(e);
                killCount += gapBtwYears;
                year += gapBtwYears;
            }
        }
    }
    private void Update()
    {
        AgeCounter.text = killCount.ToString();
        YearCounter.text = year.ToString();

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

    public void KillAllEnemies()
    {
        foreach (var e in enemiesOnScreen)
        {
            Destroy(e);
            if (e == null)
            {
                enemiesOnScreen.Remove(e);
            }
        }
        killCount = 0;
        year = startYear;
    }
}
