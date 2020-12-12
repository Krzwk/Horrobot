using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float moveSpeed = 1f;
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    [SerializeField]
    private Vector3 pointA;
    [SerializeField]
    private Vector3 pointB;
    [SerializeField]
    private Boolean direction;
    
     
    
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float amtToMove = moveSpeed * Time.deltaTime;
        if (direction)
            transform.position = Vector3.MoveTowards(transform.position, pointA, amtToMove );
        else
            transform.position = Vector3.MoveTowards(transform.position, pointB, amtToMove );
        if (transform.position == pointA)
        {
            direction = !direction;
        }
        if (transform.position == pointB)
        {
            direction = !direction;
        }
        //Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rigidBody.rotation = angle;
        //direction.Normalize();
        //movement = direction;
    }

    void moveCharacter(Vector2 direction)
    {
        rigidBody.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void FixedUpdate()
    {
       moveCharacter(movement);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if(other.tag == "Player" && player.state == PlayerController.State.Playing)
        {
             
            StartCoroutine(player.GotHit());

        }
    }
    
}
