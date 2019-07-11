using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationEnemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject FirePointEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = FirePointEnemy.transform.position - Player.transform.position;
        //Debug.Log(FirePointEnemy.transform.position);
        //Debug.Log(Player.transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Rotate(0, 180f, 0f);

    }
}
