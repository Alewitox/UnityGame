using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{

    public bool canGrab = false;

    public void onTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("I can grab");
            canGrab = true;
        }
    }

    public void onTriggerExit(Collider other)
    {
        Debug.Log("I can not grab");
        canGrab = false;
    }
}
