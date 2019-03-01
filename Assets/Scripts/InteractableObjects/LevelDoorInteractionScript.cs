using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoorInteractionScript : InteractiveObject
{
    public int nextLevelIndex;
    public override void UseItem()
    {
        if (!canInteract) return;
        SceneManager.LoadScene(nextLevelIndex);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UpdatePosition();
    }
}
