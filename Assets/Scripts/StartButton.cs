using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject Box;
    int spawnCount = 5;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == ("Player"))
        {
            if (gameObject.tag != "Started")
            {

                //Get the Renderer component from the new cube
                var renderer = GetComponent<Renderer>();
                renderer.material.SetColor("_Color", Color.green);

                gameObject.tag = "Started";
                StartCoroutine(sendBox());
            }
        }   
    }

    IEnumerator sendBox()
    {
        while (spawnCount > 0)
        {
            spawnCount--;
            yield return new WaitForSeconds(0.6f);
            Vector3 pos = new Vector3(-18.063f, 1.28f, 0.05f);
            Instantiate(Box, pos, new Quaternion(0, 0, 0, 0));

        }

    }

    void Update()
    {
        
    }
}
