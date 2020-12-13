using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediKit : MonoBehaviour
{ // Start is called before the first frame update
    public PlayerController playercontr;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("test");
            playercontr.GotRepaired();
        }
    }
}
