using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Immortal player; 
    [SerializeField] private string startingScreen;
    [SerializeField] private TMP_Text AgeCounter;
    [SerializeField] private GameObject deathScreen;

    [Header("WEAPONS")] 
    public SpriteRenderer gunRenderer;
    public Sprite gunSprite;
    public GameObject gunBullet;

    private void Start()
    {
        deathScreen.SetActive(false); 
        Time.timeScale = 1f;
    }


    private void Update()
    {
        if (player.health <= 0)
        {
            deathScreen.SetActive(true);
            GetComponent<SpawnManager>().KillAllEnemies();
            player.health = 0;
            player.rb.velocity = Vector2.zero;
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (int.Parse(AgeCounter.text.Trim()) >= 10)
        { 
            gunRenderer.sprite = gunSprite;
            player.bullet = gunBullet;
        }
    }
    public void Restart()
    {
        GetComponent<SpawnManager>().dead = false;
        GetComponent<SpawnManager>().enemiesOnScreen.Clear();
        Time.timeScale = 1f;
        player.health = player.HP;
        deathScreen.SetActive(false);
    } 
}
