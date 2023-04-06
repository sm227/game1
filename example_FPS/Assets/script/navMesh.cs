using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMesh : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        //agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
