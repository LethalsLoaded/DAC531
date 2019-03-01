using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour {

    public float speed;
    bool inProgress = false;

	void Start () {
		
	}
	



	void Update () {
        transform.Translate(new Vector3(Time.deltaTime * speed, 0,0));
        if (!inProgress)
        {
            StartCoroutine(changeDirection());
            inProgress = !inProgress;
        }
	}

    IEnumerator changeDirection()
    {
        yield return new WaitForSeconds(4);
        speed *= -1;
        inProgress = !inProgress;
    }
}
