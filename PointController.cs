using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    private float timer;
    public static float points;
    private bool loop;
    private float multiplier;

    void Start()
    {
        points = 0;
        timer = 5.0f;
        multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyDamage.death == true){
            points *= multiplier;
            points += 5;
            multiplier += 0.1f;
            loop = true;
        }
        if (loop == true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                loop = false;
            }
            text.text = "Points: " + points + "\n" + "MULTIPLIER: " + multiplier + " for " + timer.ToString("F2");
        }
           
        text.text = "Points: " + points;
    }
}
