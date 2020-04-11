/*
 * Matt Kirchoff
 * Pool.cs
 * CIS 452 Assignment 10
 * this is the pool container for prefabs 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{

    //All of these need to be set in the inspector for each pool
    public string tag;
    public GameObject prefab;
    public int size;

}
