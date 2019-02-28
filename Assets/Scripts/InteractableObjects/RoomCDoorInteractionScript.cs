using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCDoorInteractionScript : InteractiveObject
{
    public AnimationClip doorAnimation;
    public override void UseItem()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>().FindItem("C Room Key") == null)
            return;
        else
            GetComponent<Animation>().clip = doorAnimation;
    }
}
