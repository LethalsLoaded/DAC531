using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    public bool canInteract = false;
    public string interactionText = /*/ Press F /*/ "to interact with item.";

    public abstract void UseItem();
}
