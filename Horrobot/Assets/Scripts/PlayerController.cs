using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    //public CharacterController controller;
    public float moveSpeed;
    public Rigidbody2D myRigid;
    public Animator animator;

    public Vector2 move;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    public static Text gasComposition;

    private static float N2;
    private static float O2;
    private static float Ar;
    
    private static float CO2;
    private static float Kr = 3.30f;
    private static float timeBetweenCompDisplay = 1f; 
    private static float lastDisplay = 0f;
    private float blinkRate = 0.1f;
    private int numberOfTimesToBlink = 5;
    private int blinkCount = 0;
    [SerializeField]
    private GameObject playerExplosion;

    public enum MissingSenses{
        None,
        Sight,
        Smell,
        Hearing,
        Dead
    }
    public enum State{
        Playing,
        Invincible
    }
    [SerializeField]
    public static MissingSenses missingSense = MissingSenses.None;
    public State state = State.Playing;
    public static GameObject[] enemies;
    private static Boolean smellSensor = true;
    static public Light torchlight;
    void Awake()
    {
        gasComposition = GameObject.Find("GasComp").GetComponent<Text>();
        updateGasComp();
    }

    // Update is called once per frame
    void Update()
    {
        if (missingSense != MissingSenses.Dead)
        {

            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal",move.x);
            animator.SetFloat("Vertical",move.y);
            animator.SetFloat("Speed",move.sqrMagnitude);
            if(Time.time - lastDisplay > timeBetweenCompDisplay && smellSensor){
                updateGasComp();
                lastDisplay = Time.time;
            
             }
         }
    }

    private void FixedUpdate()
    {
        myRigid.MovePosition(myRigid.position + move * moveSpeed * Time.fixedDeltaTime);
        //controller.Move(new Vector3(horizontalMove*10*Time.deltaTime,verticalMove*10*Time.deltaTime,0));
    }
    public static void updateGasComp (){
        N2 = UnityEngine.Random.Range(78.00f, 78.30f);
        N2 = N2 - N2 % 0.01f;
        O2 = UnityEngine.Random.Range(20.80f, 20.981f);
        O2 = O2 - O2 % 0.01f;
        Ar = UnityEngine.Random.Range(0.90f, 0.94f);
        Ar = Ar - Ar % 0.01f;
        CO2 = UnityEngine.Random.Range(0.06f, 0.071f);
        CO2 = CO2 - CO2 % 0.01f;
        gasComposition.text = "N2: " + N2.ToString() + "%" + "\nO2: " + O2.ToString() + "%"  + "\nAr: " + Ar.ToString() + "%" + "\nCO2: " + CO2.ToString() + "%" + "\nKr: " + Kr.ToString() + " ppm";

    }
    
    public static void GotRepaired(){
        if (missingSense != MissingSenses.None)
            {
            missingSense--;
        
            if (missingSense == MissingSenses.None)
                torchlight.range = 20;
            else if (missingSense == MissingSenses.Sight)
                {
                    smellSensor = true;
                }
            else if (missingSense == MissingSenses.Smell){
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject enemy in enemies)
                    {
                        AudioSource audioSource = enemy.GetComponent<AudioSource>();
                        audioSource.mute = !audioSource.mute;
                    }
            }

            }
        

        
    }
    public IEnumerator GotHit() {
        

        missingSense++;
        if (missingSense != MissingSenses.Dead)
        {

            if (missingSense == MissingSenses.Sight)
                torchlight.range = 5;
            if (missingSense == MissingSenses.Hearing)
                {
                    enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject enemy in enemies)
                    {
                        AudioSource audioSource = enemy.GetComponent<AudioSource>();
                        audioSource.mute = !audioSource.mute;
                    }
                }
            if (missingSense == MissingSenses.Smell)
            {
                smellSensor = false;
                gasComposition.text = "N2: ERROR %\nO2: ERROR %\nAr: ERROR %\nCO2: ERROR %\nKr: ERROR ppm";
            }
            gameObject.GetComponent<Renderer>().enabled = true;
            state = State.Invincible;
            while(blinkCount < numberOfTimesToBlink){
                gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
                if(gameObject.GetComponent<Renderer>().enabled){
                    blinkCount++;
                }
                yield return new WaitForSeconds(blinkRate);
            }
            blinkCount = 0;
            state = State.Playing;
            
            
        }
        else 
        {
            
            Instantiate(playerExplosion, transform.position,Quaternion.identity);
            gameObject.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("GameOver");
        }

    }

}
