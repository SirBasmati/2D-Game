using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public static float health;
    public static int difficulty;
    public static int lives;
    public static float originalHealth;
    public static int originalLives;
    public Text healthText;
    public GameObject[] Enemies;


    private void Start()
    {
        if (ButtonController.verify == true)
        {
            Debug.Log("=======\n lives: " + lives + "\n========");

            if (difficulty == 1)
            {
                health = 200;
                lives = 5;
            }
            if (difficulty == 2)
            {
                health = 100;
                lives = 3;
            }
            if (difficulty == 3)
            {
                health = 50;
                lives = 1;
            }
            else
            {
                health = 100;
                lives = 3;
            }
            originalHealth = health;
            originalLives = lives;
            ButtonController.verify = false;
        }
    }
    private void Update()
    {
        healthText.text = "HP: " + health + "/" + originalHealth;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            health = originalHealth;
            lives -= 1;
            Debug.Log("Lives: " + lives);
        }

        if (lives <= 0)
        {
            SceneManager.LoadScene("MainMenu");
            lives = originalLives;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }

    public static void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
    }
}
