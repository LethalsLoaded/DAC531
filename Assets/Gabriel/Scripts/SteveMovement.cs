using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteveMovement : MonoBehaviour {
    bool happened = false;
    #region Things you have to delete
    public float speed;
    public float movement;
    bool ableToMove = true;


    void Update () {
        if (ableToMove)
        {
            if (Input.GetKey("w"))
                transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movement;
            else if (Input.GetKey("s"))
                transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movement;

            if (Input.GetKey("a"))
                transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movement;
            else if (Input.GetKey("d"))
                transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movement;


            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
        }
    }
    #endregion


    
    private void OnTriggerEnter(Collider other)
    {
        //If player stands on the X mark and it s the first time then
        if (other.gameObject.name == "Trigger" && !happened)
        {
            //disable movement
            ableToMove = false;

            //Start Axe animation
            StartCoroutine(startAxeAnimation());

            //assure never gonna happen again
            happened = !happened;
        }
    }

    IEnumerator startAxeAnimation()
    {
        //Start the rope sound
        yield return new WaitForSeconds(1);
        GameObject.FindObjectOfType<AudioManager>().Play("release");


        //set axe object active
        yield return new WaitForSeconds(0.6f);
        GameObject.Find("Xmark").transform.GetChild(0).gameObject.SetActive(true);

        //set animation transition
        GetComponent<Animator>().SetBool("DodgeAxe",true);


        //play Landed animation
        yield return new WaitForSeconds(0.3f);
        GameObject.FindObjectOfType<AudioManager>().Play("land");


        //diable audio Manager
        yield return new WaitForSeconds(1);
        GameObject.FindObjectOfType<AudioManager>().gameObject.SetActive(false);

        //Disable Axe animation and enable movement
        yield return new WaitForSeconds(0.9f);
        GetComponent<Animator>().SetBool("DodgeAxe", false);
        ableToMove = true;


    }


}
