using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brkCamera : MonoBehaviour
{
    private Transform player;//player
    private Vector3 Offset;
    private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        int st = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
        
    // Update is called once per frame
    void Update()
    {
        float z = player.position.z + 7;
        float x = player.position.x;
        if (z > 19f)
        {
            z = 19f;
        }

        if (x < -19f)
        {
            x = -19f;
        }

        if (x > 12f)
        {
            x = 12f;
        }

        Vector3 traget = new Vector3(x, transform.position.y, z);//Convert offset to area coordinates
        transform.position = traget;
        //transform.LookAt(player.position);
    }
}
