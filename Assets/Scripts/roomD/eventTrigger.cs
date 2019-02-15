using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTrigger : MonoBehaviour
{
    //Add event that plays
    public GameObject myEvent;
    public GameObject myEvent2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }
}
