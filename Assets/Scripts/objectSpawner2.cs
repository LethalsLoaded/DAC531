using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner2 : MonoBehaviour {

    public GameObject objectToSpawn;
    public bool willSpawn;
    public float minX, maxX, minY, maxY,minZ, maxZ;

    public float spawnTimer;

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(spawnTimer);

        //Spawn new item every x sec
        Vector3 randomVector = new Vector3(Random.Range(maxX, minX), Random.Range(maxY, minY), Random.Range(maxZ, minZ));
        Instantiate(objectToSpawn, randomVector, Quaternion.identity);

        willSpawn = true;

    }

    // Use this for initialization
    void Start () {
        willSpawn = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (willSpawn == true)
        {
            StartCoroutine(waitTime());
        }
        // Unless true set to false
        willSpawn = false;
    }
}
