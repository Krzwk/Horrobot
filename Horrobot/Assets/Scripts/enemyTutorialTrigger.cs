using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTutorialTrigger : MonoBehaviour
{
    void onTriggerEnter2D(Collider2D other){
        Debug.Log("hit invisible box");
        if (other.tag == "Player"){
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.StartCoroutine(player.whatsanenemy(this));
        }

    }
    public void destroy(){
        Destroy(this.gameObject);
    }
}
