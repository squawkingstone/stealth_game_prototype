using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    VisionCone _vision;

    void Awake() 
    {
        _vision = GetComponent<VisionCone>();
    }

    
}