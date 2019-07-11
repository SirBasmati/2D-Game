using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public Rigidbody2D rb;
    public static bool sourceOfShot;
    private int damage;
    public static float fireRate;

  


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        EnemyDamage EnemyDamage = hitInfo.GetComponent<EnemyDamage>();
        if (hitInfo.name != "Bullet(Clone)")
        {
            if (sourceOfShot == true)
            {
                Debug.Log("Invoking EnemyDamage Subroutine");
                damage = Random.Range(30, 40);
                EnemyDamage.TakeDamage(damage);
                sourceOfShot = false;
            }
            else
            {
                Debug.Log("Invoking PlayerDamage Subroutine");
                damage = Random.Range(10, 20);
                Health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
