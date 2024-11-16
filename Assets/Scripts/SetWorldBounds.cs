using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWorldBounds : MonoBehaviour
{
    private void Awake()
    {
        Bounds bounds = GetComponent<SpriteRenderer>().bounds;
        Globals.WorldBounds = bounds; 
    }
}