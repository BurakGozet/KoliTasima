using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public Material MaterialStarted;
    MeshRenderer meshRend;
    Rigidbody rigbdy;
    GameObject startButton;
    float xOff = 0;
    bool isStarted = false;
    void Start()
    {
        startButton = GameObject.Find("StartButton");
        meshRend = GetComponent<MeshRenderer>();
        rigbdy = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (startButton.transform.tag == ("Started"))
        {
            if (!isStarted)
            {
                isStarted = true;
                meshRend.material = MaterialStarted;
            }
            Vector3 pos = rigbdy.position;
            rigbdy.position -= new Vector3(2.4f, 0, 0) * Time.fixedDeltaTime;
            rigbdy.MovePosition(pos);

            xOff -= Time.fixedDeltaTime*2.6f;
            meshRend.material.mainTextureOffset = new Vector2(xOff, meshRend.material.mainTextureOffset.y);
        }
    }
}
