using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class MoveRandomly : MonoBehaviour
{
    public float timer;

    public int newtarget;

    public float speed;

    public NavMeshAgent nav;

    public Vector3 Target;


    // https://www.youtube.com/watch?v=Oqajv3vL58k&t=368s
    // Start is called before the first frame update
    // need to BAKE the cube and character in order for object to move in NAVMESH
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= newtarget) 
        {
            newTarget();
            timer = 0;
        }
    }

    void newTarget ()
    {
        float myX = gameObject.transform.position.x;
        float myZ = gameObject.transform.position.z;

        float xPos = myX + Random.Range(myX - 100, myX + 100);
        float zPos = myZ + Random.Range(myZ - 100, myZ + 100);

        Target = new Vector3(xPos, gameObject.transform.position.y,zPos);

        nav.SetDestination(Target);
    }
}
