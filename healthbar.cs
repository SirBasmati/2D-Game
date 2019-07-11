using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    private Vector3 healthBar;
    private Vector3 healthLocation;
    private float xAxis;
    public float xScale;
    public float yScale;
    private bool debug;
    // Start is called before the first frame update
    void Start()

    {
        xScale = 40f;
        yScale = 20f;
        debug = true;
        xAxis = 152.0f;

        ManipulateHealthBar(xScale, yScale, xAxis);
    }

    // Update is called once per frame
    void Update()
    {
        if (debug == true)
        {
            ManipulateHealthBar(-10, -5, xAxis);
            debug = false;
        }
    }

    private void ManipulateHealthBar(float xScale, float yScale, float xAxis)
    {
        Vector3 healthBar = transform.localScale;
        Debug.Log("Increasing xScale by " + xScale);
        healthBar.x += xScale;

        Vector3 healthLocation = transform.position;
        transform.localScale = healthBar;
        Debug.Log("Increasing yScale by " + yScale);
        healthLocation.x += yScale;

        transform.localPosition = healthLocation;
        if (xScale < 0)
        {
            xAxis -= xScale + 10;
        }
        transform.position = new Vector3(xAxis, 48, 0);

    }
}
