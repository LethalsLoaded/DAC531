using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActive : MonoBehaviour
{
    public GameObject activateObject;
    public GameObject disableObject;

    public void enableObject()
    {
        activateObject.SetActive(true);
        disableObject.SetActive(false);
    }


}
