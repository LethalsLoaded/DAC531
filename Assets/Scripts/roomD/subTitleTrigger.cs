using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class subTitleTrigger : MonoBehaviour
{
    //Add event that plays
    public GameObject mySubtitle;
    //Duration
    public float subTitleDuration;
    //Subtitle delay
    public float delaySubDuration;
    private bool subTitleDelay = true;
    //Your Text/Message
    public string myMessage;


    IEnumerator subDuration()
    {
        //Wait seconds
        yield return new WaitForSeconds(subTitleDuration);
        //Change text to blank
        mySubtitle.GetComponent<Text>().text = "";
    }

    IEnumerator subDelay()
    {
        //Wait seconds
        yield return new WaitForSeconds(delaySubDuration);

        //Display your text when colliding with a trigger
        mySubtitle.GetComponent<Text>().text = myMessage;
        //Starts coroutine
        StartCoroutine(subDuration());
    }

    private void OnTriggerEnter(Collider other)
    {
        #region fadeEvent
        if (other.tag == "Player")
        {
            //Starts delaycoroutine
            StartCoroutine(subDelay());

        }
        #endregion
    }
}
