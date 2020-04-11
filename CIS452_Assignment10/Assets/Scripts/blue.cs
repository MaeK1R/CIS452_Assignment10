/*
 * Matt Kirchoff
 * blue.cs
 * CIS 452 Assignment 10
 * this returns the object to pool when run into the drain
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blue : MonoBehaviour
{
    private ObjectPooler objectPooler;
    private Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();
        spawner = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Drain"))
        {
            objectPooler.ReturnObjectToPool("blue", this.gameObject);
        }
    }

   
}
