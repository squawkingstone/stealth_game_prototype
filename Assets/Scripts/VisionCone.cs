using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    [SerializeField] Mesh _display_mesh;
    [SerializeField] Color _display_color;
    [SerializeField] Transform _source;
    [SerializeField] float _length;
    [SerializeField] float _fov;

    public bool PlayerSpotted()
    {
        Vector3 to_player = Blackboard._player_position - _source.position;
        float angle = Vector3.Angle(_source.forward, to_player);
        float length = to_player.magnitude;

        return (angle <= _fov / 2f && length <= _length && Physics.Raycast(_source.position, to_player.normalized, _length));
    }

    void OnDrawGizmos() 
    {
       Gizmos.color = _display_color;
       Gizmos.DrawMesh(_display_mesh, _source.position, Quaternion.FromToRotation(Vector3.forward, _source.forward), Vector3.one * _length);
    }

}
