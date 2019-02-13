using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartScript : MonoBehaviour
{
    Rigidbody mRigidbody;
    public float moveSpeed = 1;
    public GameObject myCart;

    bool moveCart;



    private void Update()
    {
        //cart moves when player is behind the cart
        if (moveCart == true) { 
            myCart.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }


    }

    // disable the whole script to prevent any movement of the cart
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {
            gameObject.GetComponent<cartScript>().enabled = false;
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.tag != "Object") 
        {
            moveCart = true;
        }

        if (other.tag == "Object")
        {
            moveCart = false;
        }
    }

    // Stop moving the cart when player is not behind the cart
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            moveCart = false;
        }
    }
}
