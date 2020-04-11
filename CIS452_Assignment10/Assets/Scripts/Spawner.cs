/*
 * Matt Kirchoff
 * Spawner.cs
 * CIS 452 Assignment 10
 * this spawns the spheres using the pool pattern
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{

    ObjectPooler objectPooler;
    public int numberOfObjects;
    private int internalNum;
    public float waitTime = 1f;

    private Vector3 target;
    private Vector3 center;
    public Vector3 size;

    public Text num;
    public Text timeText;

    private float time;


    private void Start()
    {
        InvokeRepeating("Spawn", 0f, waitTime);

        objectPooler = ObjectPooler.instance;

        objectPooler = ObjectPooler.instance;
        center = new Vector3(0, 35, 0);
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        //Debug.Log("spawn");
        //objectPooler.SpawnFromPool("blue", transform.position, Quaternion.identity);

        if (numberOfObjects <= 0)
        {
            SceneManager.LoadScene(0);
        }
        num.text = ("Blue left: " + numberOfObjects.ToString());
        timeText.text = ("Time: " + time.ToString("#.00"));
    }

    private void Spawn()
    {
        target = center;
        target = center + new Vector3((Random.value - 0.5f) * size.x, (Random.value - 0.5f) * size.y, (Random.value - 0.5f) * size.z);
        objectPooler.SpawnFromPool("blue", target, Quaternion.identity);

        target = center;
        target = center + new Vector3((Random.value - 0.5f) * size.x, (Random.value - 0.5f) * size.y, (Random.value - 0.5f) * size.z);
        objectPooler.SpawnFromPool("red", target, Quaternion.identity);

    }
}
