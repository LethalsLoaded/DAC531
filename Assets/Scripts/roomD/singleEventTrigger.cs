using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singleEventTrigger : MonoBehaviour
{
    //Add event that plays
    public GameObject myEvent;
    public float eventTimer;



    IEnumerator fadeTimer()
    {
        //Wait 1 second
        yield return new WaitForSeconds(eventTimer);
    }

    private void Start()
    {
        myEvent.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        #region fadeEvent
        if (other.tag == "Player")
        {
            myEvent.SetActive(true);
        }
        #endregion
    }
}
