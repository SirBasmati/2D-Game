using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    private float fireRate;
    private float nextFire;

    private void Start()
    {
        fireRate = 0.25f;
        nextFire = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > nextFire)
            {
                Shoot();
                Bullet.sourceOfShot = true;
                nextFire = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
