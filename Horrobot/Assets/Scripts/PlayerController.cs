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

    private static float N2 = 78.08f;
    private static float O2 = 20.94f;
    private static float Ar = 0.93f;
    
    private static float CO2 = 0.06f;
    private static float Kr = 3.30f;

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
    public static void updateGasComp (){
        N2 = UnityEngine.Random.Range(78.00f, 78.30f);
        O2 = UnityEngine.Random.Range(20.80f, 20.98f);
        Ar = UnityEngine.Random.Range(0.90f, 0.94f);
        CO2 = UnityEngine.Random.Range(0.06f, 0.07f);
        gasComposition.text = "N2: " + N2.ToString() + "\nO2: " + 02.ToString() + "\nAr: " + Ar.ToString()+ "\nCO2: " + CO2.ToString()+ "\nKr: " + Kr.ToString();

    }
}
