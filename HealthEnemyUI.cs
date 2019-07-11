using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemyUI : MonoBehaviour
{
    // Start is called before the first frame updat
    public Text healthText;

    private void Update()
    {
        healthText.text = "HP: " + EnemyDamage.EnemyHealth + " " + EnemyDamage.EnemyOriginal;
    }
}
