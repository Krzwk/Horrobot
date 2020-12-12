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
    public Text text;

    [SerializeField]
    private float lastStep;

    [SerializeField]
    private float timeBetweenSteps = 0.25f;

    private bool color ;

    private int x,y,z;
    private int result = 2;

<<<<<<< Updated upstream
    //void Start(){
    //    PopUp();
   // }
=======
    void Start(){
        PopUp();   
    }
>>>>>>> Stashed changes
       
    void Update(){
        if(x==1){
            result = result*2;
            Debug.Log(result);
            x++;
        }

        if(y==2){
            result = result-4;
            Debug.Log(result);
            y++;
        }

        if(z==3){    
            result = result/2;
            Debug.Log(result);
            z++;
        }
          
        if(Time.time - lastStep > timeBetweenSteps) {
            lastStep = Time.time;
            if(x==2||y==3||z==4){
                Button btn1=Button1.GetComponent<Button>();
                Button btn2=Button2.GetComponent<Button>();
                Button btn3=Button3.GetComponent<Button>();
                btn1.GetComponent<Image>().color = Color.white;
                btn2.GetComponent<Image>().color = Color.white;
                btn3.GetComponent<Image>().color = Color.white;
                if(x==2)
                    x++;
                if(y==3)
                    y++;
                if(z==4)
                    z++;
            }
        }
            
        if(result==-6){
            Debug.Log("Yay! Solved"); 
            result = 0;
            Button btn1=Button1.GetComponent<Button>();
            Button btn2=Button2.GetComponent<Button>();
            Button btn3=Button3.GetComponent<Button>();
            btn1.GetComponent<Image>().color = Color.green;
            btn2.GetComponent<Image>().color = Color.green;
            btn3.GetComponent<Image>().color = Color.green;
        }
           
        if(x>1&&y>2&&z>3){
            result = 2;
            x=0;
            y=0;
            z=0;
        }       
   }

    public void PopUp(){
        popUpBox.SetActive(true);
        animator.SetTrigger("pop");

        Button btn1=Button1.GetComponent<Button>();
        Button btn2=Button2.GetComponent<Button>();
        Button btn3=Button3.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
        btn2.onClick.AddListener(TaskOnClick2);
        btn3.onClick.AddListener(TaskOnClick3);
         
        Text txt = text.GetComponent<Text>();
        txt.text = "Code ";
    }

    void TaskOnClick1(){
        x += 1;
        Button btn1=Button1.GetComponent<Button>();
        if(x==1){
            if(result != -3){
                btn1.GetComponent<Image>().color = Color.red;
            }
            else
                btn1.GetComponent<Image>().color = Color.green;
            }
        lastStep = Time.time;
    }

    void TaskOnClick2(){
        y += 2;
        Button btn2=Button2.GetComponent<Button>();
        if(y==2){
            if(result != 1)
                btn2.GetComponent<Image>().color = Color.red;
            else    
                btn2.GetComponent<Image>().color = Color.green;
        }
        lastStep = Time.time;
    }

    void TaskOnClick3(){
        z += 3;
        Button btn3=Button3.GetComponent<Button>();
        if(z==3){
            if(result != 2)
                btn3.GetComponent<Image>().color = Color.red;
            else     
                btn3.GetComponent<Image>().color = Color.green;    
        }
        lastStep = Time.time;
    }
}

