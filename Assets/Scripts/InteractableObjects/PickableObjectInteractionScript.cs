using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectInteractionScript : InteractiveObject
{
    public GameObject areaHolder;

    public override void UseItem()
    {
        // If object is already in hand
        if(gameObject.transform.parent == areaHolder.transform)
        {
            Throw();
            return;
        }
        if(areaHolder.transform.childCount == 1)
        {
            areaHolder.transform.GetChild(0).parent = null;
            gameObject.transform.parent = areaHolder.transform;
            gameObject.transform.localPosition = Vector3.zero;
            return;
        }

        gameObject.transform.parent = areaHolder.transform;
        gameObject.transform.localPosition = Vector3.zero;
        
    }

    void Throw()
    {
        Debug.Log("Yeet");
        gameObject.transform.parent = null;
        var body = gameObject.AddComponent<Rigidbody>();
        body.AddForce(Camera.main.transform.forward * 10);
        Invoke("FinishThrow", 5.0f);
    }

    void FinishThrow()
    {
        Destroy(gameObject.GetComponent<Rigidbody>());
    }
}
