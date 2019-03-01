using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoorInteractionScript : InteractiveObject
{
    public string nextLevelname;
   public override void UseItem()
   {
       SceneManager.LoadScene(nextLevelname);
       GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UpdatePosition();
   }
}
