using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AndGamePopUp : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    


    public void Start()
    {
        PopUp();
    }

    public void PopUp()
    {
        popUpBox.SetActive(true);
        animator.SetTrigger("pop");
        Button btt1 = button1.GetComponent<Button>();
        btt1.onClick.AddListener(TaskOnClick1);
        
    }

    void TaskOnClick1()
    {
        var colors = GetComponent<Button> ().colors;
        colors.normalColor = Color.red;
        GetComponent<Button> ().colors = colors;
    }

}
