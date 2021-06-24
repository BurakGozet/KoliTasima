using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingConveyor : MonoBehaviour
{
    public Material MaterialStarted;
    public RectTransform spritePrefab;
    private RectTransform handImage;
    private MeshRenderer meshRend;
    private Rigidbody rigbdy;
    float xOff = 0;
    GameObject startButton;
    public GameObject ConveyorTarget;
    public bool isConnectConveyor = false;
    bool isStarted = false;

    void Start()
    {
       Transform mainObj = transform.Find("ConveyorBody");
        

        startButton = GameObject.Find("StartButton");

        meshRend = mainObj.gameObject.GetComponent<MeshRenderer>();
        rigbdy = this.GetComponent<Rigidbody>();

        var handIcons = GameObject.Find("SelectHandConveyor").transform;
        handImage = Instantiate(spritePrefab, handIcons);

    }
    void Update()
    {
        if (!isStarted && handImage != null)
        {
            var screenpos = Camera.main.WorldToScreenPoint(transform.position);
            handImage.position = screenpos;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == ("Target"))
        {
            transform.position = hit.transform.position;
            transform.rotation = hit.transform.rotation;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,-180f,transform.eulerAngles.z);
            rigbdy.isKinematic = true;
            isConnectConveyor = true;
            Destroy(ConveyorTarget);

        }
        if (hit.gameObject.tag == ("Player") && handImage != null)
        {
            Destroy(handImage.gameObject);
        }
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

            if (rigbdy.isKinematic)
            {
                Vector3 pos = rigbdy.position;
                rigbdy.position -= new Vector3(2.4f, 0, 0) * Time.fixedDeltaTime;
                rigbdy.MovePosition(pos);

                xOff -= Time.fixedDeltaTime*2.6f;
                meshRend.material.mainTextureOffset = new Vector2(xOff, meshRend.material.mainTextureOffset.y);
            }
        }
    }

}
