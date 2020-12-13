using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource SGJ_M1V3_Default;

    public AudioClip otherClip;

     // Start is called before the first frame update
    void Start()
    {
        SGJ_M1V3_Default = GetComponent<AudioSource>();
        SGJ_M1V3_Default.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!SGJ_M1V3_Default.isPlaying)
        {
            SGJ_M1V3_Default.clip = otherClip;
            SGJ_M1V3_Default.Play();
            SGJ_M1V3_Default.loop = true;
  
        }

    }
}