using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PathFollow : MonoBehaviour
{
    [System.Serializable]
    public class Waypoint
    {
        public Vector3 _point; 
        public float _wait_time; // if we want the guy to just sort of wait here
    }

    [SerializeField] List<Waypoint> _path;
    [SerializeField] bool _is_cyclic;

    NavMeshAgent _agent;
    int _counter = 1;

    bool _stationary;
    bool _reversing = false;

    void Awake() 
    { 
        _agent = GetComponent<NavMeshAgent>(); 
    }

    void Start() 
    {
        _stationary = (_path.Count <= 1) ? true : false;
        
        if (_path.Count >= 1) _agent.Warp(_path[0]._point);

        if (!_stationary) StartCoroutine(Follow());
    }

    private IEnumerator Follow()
    {
        while (true)
        {
            while (_agent.remainingDistance >= 0.001f) { yield return null; }

            yield return new WaitForSeconds(_path[_counter]._wait_time);
            
            _agent.SetDestination(_path[_counter]._point);

            _counter += (_reversing) ? -1 : 1;
            if (_counter == _path.Count) 
            {
                if (_is_cyclic) { _counter = 0; }
                else 
                { 
                    _reversing = true;
                    _counter = _path.Count - 2;
                }
            }
            if (_counter == -1) { _reversing = false; _counter = 1; }
        }
    }

    void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < _path.Count; i++)
        {
            Gizmos.DrawSphere(_path[i]._point, 0.1f);
        }
    }

}
