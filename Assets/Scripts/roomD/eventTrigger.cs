using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventTrigger : MonoBehaviour
{
    //Add event that plays
    public GameObject myEvent;
    //To disable movement
    public GameObject myPlayer;

    public float eventTimer;
    // event has not occured
    // Idea would be to make this script modular
    public bool fadeEvent;
    public bool setActiveEvent;
    public bool setActiveAndDestroy;
    


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

    IEnumerator setActiveEventTimer()
    {
        //Wait second
        yield return new WaitForSeconds(eventTimer);
        myEvent.SetActive(true);
    }


    IEnumerator setActiveAndDestroyEventTimer()
    {
        //Wait second
        yield return new WaitForSeconds(eventTimer);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        #region fadeEvent
        if (other.tag == "Player" && fadeEvent == true)
        {
            myEvent.GetComponent<Animator>().enabled = true;
            myEvent.GetComponent<Image>().enabled = true;

            //Find the player and disable controls
            myPlayer.GetComponent<PlayerController>().enabled = false;

            //fadeEvent happened
            fadeEvent = false;
            //Starts coroutine
            StartCoroutine(fadeTimer());

        }
        #endregion

        #region objectEnabled
        if (other.tag == "Player" && setActiveEvent == true)
        {

            //objectActivation happened
            setActiveEvent = false;
            //Starts coroutine
            StartCoroutine(setActiveEventTimer());

        }
        #endregion

        #region objectEnabledAndDestroyed
        if (other.tag == "Player" && setActiveAndDestroy == true)
        {

            //objectActivation happened
            myEvent.SetActive(true);
            setActiveAndDestroy = false;
            //Starts coroutine
            StartCoroutine(setActiveAndDestroyEventTimer());

        }
        #endregion
    }


}
