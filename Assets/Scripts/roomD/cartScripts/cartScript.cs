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
        if (moveCart == true)
            myCart.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.tag != "Object") 
        {
            moveCart = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            moveCart = false;
        }
    }
}
