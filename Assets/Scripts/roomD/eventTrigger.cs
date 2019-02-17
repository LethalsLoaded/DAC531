using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventTrigger : MonoBehaviour
{
    //Add event that plays
    public GameObject myEvent;
    public GameObject myPlayer;

    public float eventTimer;
    // event has not occured
    // Idea would be to make this script modular
    private bool fadeEvent = false;


    IEnumerator fadeTimer()
    {
        //Wait 1 second
        yield return new WaitForSeconds(eventTimer);
        myEvent.GetComponent<Animator>().enabled = false;
        myEvent.GetComponent<Image>().enabled = false;

        //Allows player movement again
        myPlayer.GetComponent<PlayerController>().enabled = true;

        //We no longer require the event
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        #region fadeEvent
        if (other.tag == "Player" && fadeEvent == false)
        {
            myEvent.GetComponent<Animator>().enabled = true;
            myEvent.GetComponent<Image>().enabled = true;

            //Find the player and disable controls
            myPlayer.GetComponent<PlayerController>().enabled = false;

            //fadeEvent happened
            fadeEvent = true;
            //Starts coroutine
            StartCoroutine(fadeTimer());

        }
        #endregion
    }
}
