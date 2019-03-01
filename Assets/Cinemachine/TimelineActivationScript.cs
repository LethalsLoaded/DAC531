using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineActivationScript : MonoBehaviour
{
    public GameObject timeline;
    public float disableInSeconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            timeline.SetActive(true);
            StartCoroutine(Timeline());
        }
    }

    IEnumerator Timeline()
    {
        yield return new WaitForSeconds(disableInSeconds);
        timeline.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
