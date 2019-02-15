using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTrigger : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }
}
