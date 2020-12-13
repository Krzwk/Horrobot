using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lösung : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        popUpBox.SetActive(true);
    }

    // Update is called once per frame
    public void PopUp(){
        animator.SetTrigger("pop");
    }
}
