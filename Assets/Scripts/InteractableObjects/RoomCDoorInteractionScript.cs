using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCDoorInteractionScript : InteractiveObject
{
    private bool isOpen = false;
    public AnimationClip doorAnimation;
    public override void UseItem()
    {
        if(isOpen) return;

        if(GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>().FindItem("C Room Key") == null)
            return;
        else
        {
            
            transform.Rotate(new Vector3(0.0f, -90, 0.0f));
            isOpen = true;
        }
    }
}
