using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteractionScript : InteractiveObject
{
    public string nextLevelName;
    public AnimationClip doorAnimation;
    bool isOpen = false;
    public override void UseItem()
    {
        if(isOpen) return;
        transform.Rotate(new Vector3(0.0f, -90, 0.0f));
        isOpen = true;
        SceneManager.LoadScene(nextLevelName);
    }
}
