using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PfützleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public CodeMinigame test;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            Debug.Log("hello");
            test.PopUp();
        }
    }
}
