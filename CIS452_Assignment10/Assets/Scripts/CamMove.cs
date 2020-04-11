/*
 * Matt Kirchoff
 * CamMove.cs
 * CIS 452 Assignment 10
 * this moves the camera around the scene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("CamPoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
