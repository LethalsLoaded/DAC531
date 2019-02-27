using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActive : MonoBehaviour
{
    public GameObject activateObject;
    public GameObject disableObject;

    public void enableandDisableObject()
    {
        activateObject.SetActive(true);
        disableObject.SetActive(false);
    }

    public void disableOnly()
    {
        disableObject.SetActive(false);
    }


}
