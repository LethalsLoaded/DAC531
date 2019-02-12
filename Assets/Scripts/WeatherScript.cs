using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AzureSky;

public class WeatherScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AzureSkyController skyController; 
    public int minSecond;
    public int maxSeconds;
    void Start()
    {
        skyController.SetNewWeatherProfile(1);
        StartCoroutine(Thunder());
    }    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("switch to indoor weather");
            skyController.SetNewWeatherProfile(2);
        }
    }
    IEnumerator Thunder()
    {
        yield return new WaitForSeconds(Random.Range(minSecond,maxSeconds));
        skyController.PlayThunderEffectRandom();
        yield return new WaitForSeconds(5);
        StartCoroutine(Thunder());
    }
    
}
