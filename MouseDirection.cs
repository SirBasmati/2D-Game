using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseCoords = Input.mousePosition;
        mouseCoords.z = 5.23f;
        Vector3 objectCoords = Camera.main.WorldToScreenPoint(transform.position);
        mouseCoords.x -= objectCoords.x;
        mouseCoords.y -= objectCoords.y;

        float angle = Mathf.Atan2(mouseCoords.y, mouseCoords.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.LookAt(Vector3.zero);
    }
}
