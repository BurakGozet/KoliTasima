using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{
    public GameObject dieEffectsPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision hit)
    {   
        if(hit.gameObject.tag == ("Box"))
        {
            var instance = Instantiate(dieEffectsPrefab, transform.position, dieEffectsPrefab.transform.rotation);
            Destroy(instance.gameObject, 1);
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == ("Finish"))
        {
            Destroy(hit.gameObject);
        }
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
