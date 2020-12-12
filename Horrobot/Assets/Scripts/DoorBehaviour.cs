using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public void Start()
    {
        DoorClosed();
    }

    public void DoorClosed()
    {
        Debug.Log("must be killed");
        Destroy(this.gameObject);
    }
}
