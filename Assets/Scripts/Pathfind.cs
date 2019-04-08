using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfind : MonoBehaviour
{
    [SerializeField] Transform _destination;

    NavMeshAgent _agent;

    private void Awake() 
    {
        _agent = GetComponent<NavMeshAgent>();    
    }

    [ContextMenu("Path To Destination")]
    private void Path()
    {
        _agent.SetDestination(_destination.position);
    }

}
