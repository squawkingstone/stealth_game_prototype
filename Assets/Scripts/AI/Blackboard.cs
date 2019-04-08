using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard
{
    public class PlayerProperties
    {
        public Vector3 position = Vector3.negativeInfinity;
        public float loudness   = 0f;
        public float visibility = 0f; 
    }

    public static PlayerProperties Player;

    private static Mesh _fov_mesh = null;
    public static Mesh FovMesh
    {
        get
        {
            if (_fov_mesh == null)
            {
                _fov_mesh = GenerateFovMesh(90f, 5f);
            }
            return _fov_mesh;
        }
        private set;
    }

    private static Mesh GenerateFovMesh(float fov, float length)
    {
        // generate the fov mesh
        return null; 
    }
}
