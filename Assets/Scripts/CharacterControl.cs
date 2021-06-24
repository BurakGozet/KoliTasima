using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    private CharacterController _controller;
    private Animator anim;
    public float speed = 1f;
    private bool isTouchConveyor = false;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }



    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == ("Conveyor"))
        {
            MovingConveyor MoveConveyor = hit.gameObject.GetComponent<MovingConveyor>();
            if (!MoveConveyor.isConnectConveyor)
            {
                anim.SetBool("Push", true);
                isTouchConveyor = true;
            }
        }
    }
        
    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == ("Conveyor"))
        {
            anim.SetBool("Push", false);
            isTouchConveyor = false;
        }
    }
    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Rigidbody body = hit.collider.attachedRigidbody;
    //    if (body != null && !body.isKinematic)
    //        body.velocity += hit.controller.velocity;
    //}
    void Update()
    {


        float moveHorizontal = Input.GetAxisRaw("Horizontal") * -5.0f;
        float moveVertical = Input.GetAxisRaw("Vertical") * -5.0f;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            if (isTouchConveyor)
            {
                anim.SetBool("Push", true);
            }
            else
            {
                anim.SetBool("Walking", true);
            }
            transform.rotation = Quaternion.LookRotation(movement);

            _controller.Move(movement * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Push", false);
            anim.SetBool("Walking", false);
        }


    }



}