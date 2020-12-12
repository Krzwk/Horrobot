using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    //public CharacterController controller;
    public float moveSpeed;
    public Rigidbody2D myRigid;

    public Vector2 move;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    public static Text gasComposition;

    private static float N2;
    private static float O2;
    private static float Ar;
    
    private static float CO2;
    private static float Kr = 3.30f;
    private static float timeBetweenCompDisplay = 1f; 
    private static float lastDisplay = 0f;

    void Awake()
    {
        gasComposition = GameObject.Find("GasComp").GetComponent<Text>();
        updateGasComp();
    }

    // Update is called once per frame
    void Update()
    {
         move.x = Input.GetAxisRaw("Horizontal");
         move.y = Input.GetAxisRaw("Vertical");
         if(Time.time - lastDisplay > timeBetweenCompDisplay){
             updateGasComp();
             lastDisplay = Time.time;
            
             }
    }

    private void FixedUpdate()
    {
        myRigid.MovePosition(myRigid.position + move * moveSpeed * Time.fixedDeltaTime);
        //controller.Move(new Vector3(horizontalMove*10*Time.deltaTime,verticalMove*10*Time.deltaTime,0));
    }
    public static void updateGasComp (){
        N2 = UnityEngine.Random.Range(78.00f, 78.30f);
        N2 = N2 - N2 % 0.01f;
        O2 = UnityEngine.Random.Range(20.80f, 20.981f);
        O2 = O2 - O2 % 0.01f;
        Ar = UnityEngine.Random.Range(0.90f, 0.94f);
        Ar = Ar - Ar % 0.01f;
        CO2 = UnityEngine.Random.Range(0.06f, 0.071f);
        CO2 = CO2 - CO2 % 0.01f;
        gasComposition.text = "N2: " + N2.ToString() + "%" + "\nO2: " + O2.ToString() + "%"  + "\nAr: " + Ar.ToString() + "%" + "\nCO2: " + CO2.ToString() + "%" + "\nKr: " + Kr.ToString() + " ppm";

    }
}
