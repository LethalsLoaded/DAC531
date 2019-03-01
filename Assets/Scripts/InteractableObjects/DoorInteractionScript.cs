using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionScript : InteractiveObject
{
    public AnimationClip doorAnimation;
    bool isOpen = false;
    public override void UseItem()
    {
        if(!canInteract) return;
        if(isOpen) return;
        transform.Rotate(new Vector3(0.0f, -90, 0.0f));
        isOpen = true;
    }
}
