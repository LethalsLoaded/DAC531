using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLightScript : MonoBehaviour
{
    public float MaxReduction;
     public float MaxIncrease;
     public float RateDamping;
     public float Strength;
     public bool StopFlickering;
 
     private Light lightSource;
     private float intensity;
     private bool flickering;
 
 
     public void Start()
     {
         lightSource = GetComponent<Light>();

         intensity = lightSource.intensity;
         StartCoroutine(DoFlicker());
     }
 
     void Update()
     {
         if (!StopFlickering && !flickering)
         {
             StartCoroutine(DoFlicker());
         }
     }
 
      IEnumerator DoFlicker()
     {
         flickering = true;
         while (!StopFlickering)
         {
             lightSource.intensity = Mathf.Lerp(lightSource.intensity, Random.Range(intensity - MaxReduction, intensity + MaxIncrease), Strength * Time.deltaTime);
             yield return new WaitForSeconds(RateDamping);
         }
         flickering = false;
     }
}
