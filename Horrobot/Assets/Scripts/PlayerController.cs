using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    //public CharacterController controller;
    public float moveSpeed;
    public Rigidbody2D myRigid;

    public Vector2 move;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;

    // Update is called once per frame
    void Update()
    {
         move.x = Input.GetAxisRaw("Horizontal");
         move.y = Input.GetAxisRaw("Vertical");
         
    }

    private void FixedUpdate()
    {
        myRigid.MovePosition(myRigid.position + move * moveSpeed * Time.fixedDeltaTime);
        //controller.Move(new Vector3(horizontalMove*10*Time.deltaTime,verticalMove*10*Time.deltaTime,0));
    }
}
