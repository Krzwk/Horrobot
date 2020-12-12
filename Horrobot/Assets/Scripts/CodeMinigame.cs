using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CodeMinigame : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;   
    public Button Button1;
    public Button Button2;
    public Button Button3;

    private int x,y,z,result;

    //void Start(){
    //    PopUp();
   // }
       
//     void Update(){
//         while(result!=8)
//        {
//             if(x==1){
//                 result = result*4;
//             }
//             if(y==2){
//                 result = result-2;
//             }
//             if(z==3){
//                 result = result/3;
//             }
//             if(x==1&&y==2&&z==3){
//                 result = 0;
//                 x=1;
//                 y=2;
//                 z=3;
//             }
//         }
//            Debug.Log("Yay! Solved"); 
//    }

   


    public void PopUp()
    {
        popUpBox.SetActive(true);
        animator.SetTrigger("pop");

        Button btn1=Button1.GetComponent<Button>();
        Button btn2=Button2.GetComponent<Button>();
        Button btn3=Button3.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
        btn2.onClick.AddListener(TaskOnClick2);
        btn3.onClick.AddListener(TaskOnClick3);


    }

    void TaskOnClick1(){
        x =+ 1;
    }
     void TaskOnClick2(){
        y =+ 2;
    }
     void TaskOnClick3(){
        z =+ 3;
    }


}

