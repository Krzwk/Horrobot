using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gascloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("hit invisible box");
        if (other.tag == "Player"){
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.gettingPoisoned();
        }
        }
    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player"){
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.gettingAir();
    }
    }
}



