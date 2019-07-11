using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private float timer;

    public Text TimerText;

    private GameObject Enemy;

    public GameObject[] Enemies;

    void Start()
    {
        timer = 15.0f;
        TimerText.text = "woah";
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        TimerText.text = "Time left: " + timer.ToString("F2");
        timer -= Time.deltaTime;
        //Debug.Log(EnemyDamage.death);
        if (EnemyDamage.death == true)
        {
            timer += 5.0f;
            EnemyDamage.death = false;
        }
        if (timer < 0 || Health.health <= 1)
        {
            GameEnd();
            SceneManager.LoadScene("MainMenu");
        }

        if (Enemies.Length == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Health.health = Health.originalHealth;
            Health.lives = Health.originalLives;
        }

        //Debug.Log(timer);
    }

    private void GameEnd()
    {
        TimerText.text = "GAME OVER";
    }
}
