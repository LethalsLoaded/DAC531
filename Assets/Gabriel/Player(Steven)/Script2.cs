using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script2 : MonoBehaviour {

    public float backDodge;

    Animator anim;

    #region Bool Variables

    bool q = false;
    bool shift = false;
    bool f = false;
    bool esc = false;
    bool push = false;
    bool open = false;
    bool close = false;
    bool forceDoor = false;
    bool DodgeAxe = false;

    #endregion


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	

    // Update is called once per frame
    void Update () {
        //set SCARED animation off
        anim.SetBool("scared", false);
        anim.SetBool("DodgeAxe", false);

        //toggle WALK animation by pressing key 1
        if (Input.GetKeyDown(KeyCode.Alpha1) && !q)
        {
            anim.SetFloat("speed", 2);
            q = true;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1) && q)
        {
            anim.SetFloat("speed", 0);
            q = false;
        }

        //toggle RUN animation by pressing key 2 (it only starts from walk animation)
        if (Input.GetKeyDown(KeyCode.Alpha2) && !shift)
        {
            anim.SetBool("run", true);
            shift = !shift;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && shift)
        {
            anim.SetBool("run", false);
            shift = !shift;
        }

        //start SCARED animation (it toggles off automatically)
        if (Input.GetKeyDown(KeyCode.Alpha3))
            anim.SetBool("scared", true);

        //toggle DEAD animation by pressing key 4
        if (Input.GetKeyDown(KeyCode.Alpha4) && !esc)
        {
            anim.SetBool("dead", true);
            esc = !esc;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && esc)
        {
            anim.SetBool("dead", false);
            esc = !esc;

        }

        //toggle PUSH animation by pressing key 5 (can be hold as much as you want)
        if (!push && Input.GetKeyDown(KeyCode.Alpha5))
        {
            anim.SetBool("push", true);
            anim.SetFloat("speed", 1);
            push = !push;
        }
        else if(push && Input.GetKeyUp(KeyCode.Alpha5))
        {
            anim.SetBool("push", false);
            anim.SetFloat("speed", 0);
            push = !push;

        }

        //toggle OPEN animation by pressing key 6
        if (!open && Input.GetKeyDown(KeyCode.Alpha6))
        {
            anim.SetBool("open", true);
            open=!open;
        }
        else if (open && Input.GetKeyUp(KeyCode.Alpha6))
        {
            anim.SetBool("open", false);
            open = !open;

        }

        //toggle CLOSE animation by pressing key 7
        if (!close && Input.GetKeyDown(KeyCode.Alpha7))
        {
            anim.SetBool("close", true);
            close = !close;
        }
        else if (close && Input.GetKeyUp(KeyCode.Alpha7))
        {
            anim.SetBool("close", false);
            close = !close;

        }

        //toggle FORCE DOOR animation by pressing key 8
        if (!forceDoor && Input.GetKeyDown(KeyCode.Alpha8))
        {
            anim.SetBool("forceDoor", true);
            forceDoor = !forceDoor;
        }
        else if (forceDoor && Input.GetKeyUp(KeyCode.Alpha8))
        {
            anim.SetBool("forceDoor", false);
            forceDoor = !forceDoor;

        }

        //toggle DODGE AXE animation by pressing key 9
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            anim.SetBool("DodgeAxe", true);
            StartCoroutine(dodgeForce());
        }



    }
    IEnumerator dodgeForce()
    {
        yield return new WaitForSeconds(0.8f);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -backDodge));
    }
}

