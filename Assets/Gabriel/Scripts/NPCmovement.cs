using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCmovement : MonoBehaviour {
    #region Public Variables

    //to be deleted
    public GameObject obj;


    public LayerMask groundLayer;
    public float rayLength;

    #endregion

    #region Private Variables

    bool possible = true;

        NavMeshAgent agent;
        Vector3 position;
        Animator anim;
        RaycastHit hit;

    #endregion

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        //stop slowing down when approaching the destination
        agent.autoBraking = false;


        //First point to be generated

        //Get a random position
        position = RandomNavSphere(transform.position, 15, -1);

        #region TO BE DELETED 

                //instantiate a obj to see where that position is on the map
                Instantiate(obj, position, Quaternion.identity);

        #endregion

        //set a destination
        agent.SetDestination(position);

        //set animation working
        anim.SetFloat("speed", 1);

    }

    // Update is called once per frame
    void Update()
    {
        #region TO BE DELETED

                //If press Space
                if(Input.GetKeyDown(KeyCode.Space))
                {

                    //and the agent is stopped, Resume agent
                    if (agent.isStopped)
                    {
                        anim.SetFloat("speed", 1);
                        agent.isStopped = false;

                    }

                    //if the agent is walking, Stop agent
                    else
                    {
                        agent.isStopped = true;
                        anim.SetFloat("speed", 0);
                    }
                }


        #endregion

        //if agent almost reached the point
        if (agent.remainingDistance < 0.2f)
        {

            //stop the agent
            agent.velocity = Vector3.zero;
            agent.isStopped = !agent.isStopped;

            //disable animation
            anim.SetFloat("speed", 0);

            //get another random position
            position = RandomNavSphere(transform.position, 15, -1);


            //instantiate a obj to see where that position is on the map
            Instantiate(obj, position, Quaternion.identity);

            //resume agent movement
            agent.isStopped = !agent.isStopped;

            //set agent rotation towards the next steering point
            StartCoroutine(lookAtSteeringTarget());

            //set a destination
            agent.SetDestination(position);

            //play animation
            anim.SetFloat("speed", 1);

        }

        //if the raycast catches something
        if (Physics.Raycast(transform.position, transform.position + transform.forward, out hit, rayLength, groundLayer))
        {

            //caught a door and if this movement is possible (possible var kills spamming animation)
            if (hit.transform.CompareTag("Door") && possible)
            {
                //stop the agent
                agent.isStopped = true;
                agent.velocity = Vector3.zero;

                //possibility for doing the animation again is false
                possible = !possible;

                //untag the door if it was oppened
                hit.collider.gameObject.tag = "Untagged";


                //play animation
                anim.SetBool("openDoor", true);

                //stop animation after 2 sec
                StartCoroutine(stopOpenDoorAnim());
            }
            else if(hit.transform.CompareTag("PickableItem") && possible)
            {
                //stop agent
                agent.isStopped = true;
                agent.velocity = Vector3.zero;

                //posibility for doing animation again is false
                possible = !possible;

                //destroy or remove Item
                hit.collider.gameObject.SetActive(false);

                //play animation
                anim.SetBool("pick", true);

                //stop animation afre   sec
                StartCoroutine(stopPickItem());
            }
        }


    }

    IEnumerator stopPickItem()
    {
        yield return new WaitForSeconds(1);

        //stop anim
        anim.SetBool("pick", false);

        //resume moving
        agent.isStopped = false;

        yield return new WaitForSeconds(1);
        possible = !possible;
    }


    IEnumerator stopOpenDoorAnim()
    {
        yield return new WaitForSeconds(2);
        
        //stop animation
        anim.SetBool("openDoor", false);

        //resume moving
        agent.isStopped = false;


        yield return new WaitForSeconds(1);

        //make possible to open another door
        possible = !possible;

    }

    IEnumerator lookAtSteeringTarget()
    {
        yield return new WaitForSeconds(0.1f);
        
        //rotate agent towards the next steering point
        transform.LookAt(agent.steeringTarget);

    }

    Vector3 RandomNavSphere( Vector3 origin, float distance, int layer)
    {
        //get a random direction in a unit Sphere within a given distance 
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        //add the origin of the player
        randomDirection += origin;

        //navHit is used for getting the closest point within the navMesh (alike a RaycastHit, but for navMesh)
        NavMeshHit navHit;

        //apply the NavMesh Raycast towards that direction and if hit, return that
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layer);

        return navHit.position;
    }

}
