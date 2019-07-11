using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public static float EnemyHealth;
    public static float EnemyOriginal;
    public static float DMG;
    public static float fireRate;
    

    public Transform FirePoint;
    public GameObject bulletPrefab;
    public GameObject Player;

    public int EnemyArmour;
    public static bool death;

    private bool takenDamage;

    //private float originalPosition;
    //private float currentTime;
    private float nextFire;
    //private float roam;
    //private float roamZAxis;
    private Text text;
    private float distance;
    
 

    void Start()
    {
        takenDamage = false;
        Font DTMMono; //Initialization for health bars on top of enemies
        DTMMono = (Font)Resources.GetBuiltinResource(typeof(Font), "DTM-Mono.ttf");
        GameObject HPPool = new GameObject
        {
            name = "HP Canvas"
        };
        HPPool.AddComponent<Canvas>();
        HPPool.AddComponent<CanvasScaler>();
        HPPool.AddComponent<GraphicRaycaster>();

        Debug.Log("Generated canvas components");

        Canvas canvas;
        canvas = HPPool.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;

        GameObject textHP = new GameObject
        {
            name = "EnemyHP"
        };
        textHP.transform.parent = HPPool.transform;
        textHP.AddComponent<Text>();

        Debug.Log("GameObject EnemyHP generated");

        text = textHP.GetComponent<Text>();
        text.font = DTMMono;
        text.fontSize = 6;
        text.alignment = TextAnchor.MiddleCenter;

        Debug.Log("Text Configuration generated");

        EnemyHealth = Random.Range(70, 120);
        EnemyArmour = Random.Range(0, 2);
        //originalPosition = 0f;
        death = false;
        EnemyOriginal = EnemyHealth;
        fireRate = 1f;
        nextFire = 0f;
    }

    private void Update()
    {
        //Roam();
        if (takenDamage == true)
        {
            text.text = "HP: " + DMG + "/" + EnemyOriginal;
        }

        distance = Vector3.Distance(Player.transform.position, transform.position);
        //Debug.Log(distance);
        if (distance < 4 && Time.time > nextFire)
        {
            ShootPlayer();
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
        takenDamage = true;
        float ArmourReduction = 1 - (0.052f * EnemyArmour / (0.9f + (0.048f * EnemyArmour))); //Armour calculation which decreases the projectile's effectiveness. Armour-piercing projectiles ignore armour
        EnemyHealth -= (damage * ArmourReduction);
        Debug.Log("DMG: " + DMG + "\n" + "EnemyHealth: " + EnemyHealth);

        if ((EnemyHealth - DMG) <= 0)
        {
            Destroy(gameObject);
            death = true;
        }


    }

    public void ShootPlayer()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        nextFire = Time.time + fireRate;
    }

   /* public void RoamingQueue()
    {
        roamZAxis = Random.Range(-20, 20);
        gameObject.transform.Translate(roamZAxis, 0f, 0f);
    }

    public void Roam()
    {
        RoamingQueue();


    }*/
}
