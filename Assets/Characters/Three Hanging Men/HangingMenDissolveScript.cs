using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingMenDissolveScript : MonoBehaviour
{
   public ParticleSystem[] particles;
   public Material[] material;
    bool isDissolving = false;
       public float speed;
        

        void OnTriggerEnter(Collider col)
        {
                if (col.transform.tag == "Player")
                isDissolving = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (isDissolving)
            {
                //Animating cutout
                foreach (var matts in material)
                {
                    matts.SetFloat("_DissolveCutoff", speed * Time.time);
                }
                foreach (var item in particles)
                {
                    item.gameObject.SetActive(true);
                }
            }
        }
}
