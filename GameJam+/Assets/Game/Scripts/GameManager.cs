using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Immortal player; 
    [SerializeField] private string startingScreen;
     

    private void Update()
    {
        if (player.health <= 0)
        {
            player.rb.velocity = Vector2.zero; 
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(startingScreen);
        //Time.timeScale = 1f; 
        //player.health = player.HP;
        //deathScreen.SetActive(false);
    } 
}
