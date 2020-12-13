using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float moveSpeed = 1f;
    public Animator animator;
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    [SerializeField]
    private Vector3 pointA;
    [SerializeField]
    private Vector3 pointB;
    [SerializeField]
    private Boolean direction;
    [SerializeField]
    private GameObject enemyExplosion;
    Boolean exploded = false;
    

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

        if (direction)
        {
            //if ((pointA - transform.position).x > 0)
            //    animator.SetFloat("Horizontal",1f);
                
            //if ((pointA - transform.position).x < 0)
            //    animator.SetFloat("Horizontal",-1f);
            //if ((pointA - transform.position).y > 0)
            //    animator.SetFloat("Vertical",1f);
            //if ((pointA - transform.position).y < 0)
            //    animator.SetFloat("Vertical",-1f);
            if ((pointA - transform.position).x == 0)
                animator.SetFloat("Vertical",(pointA - transform.position).y);
            else if ((pointA - transform.position).y == 0)
                 animator.SetFloat("Horizontal",(pointA - transform.position).y);
        }
        else
            {
            if ((pointB - transform.position).x > 0)
                animator.SetFloat("Horizontal",1f);
                
            if ((pointB - transform.position).x < 0)
                animator.SetFloat("Horizontal",-1f);
            if ((pointB - transform.position).y > 0)
                animator.SetFloat("Vertical",1f);
            if ((pointB - transform.position).y < 0)
                animator.SetFloat("Vertical",-1f);
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
             
            player.hit();
            Instantiate(enemyExplosion, transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    
}
