using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float power;
    public float radius;
    private Spawner spawner;

    public AudioSource audioSource;
    public AudioClip shot;
    public AudioClip explode;
    public AudioClip collect;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {  
            audioSource.PlayOneShot(shot);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("blue"))
                {
                    Destroy(hit.collider.gameObject);
                    //Debug.Log("Hit " + hit.transform.gameObject.name);
                    int temp = spawner.numberOfObjects;
                    //Debug.Log(temp);
                    audioSource.PlayOneShot(collect);
                    spawner.numberOfObjects = temp - 1;
                }
                if (hit.collider.gameObject.CompareTag("red"))
                {

                    Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                    Vector3 target = rb.gameObject.transform.position;
                    Collider[] colliders = Physics.OverlapSphere(target, radius);
                    foreach (Collider col in colliders)
                    {
                        Rigidbody rb2 = col.GetComponent<Rigidbody>();
                        if (rb2 != null)
                        {
                            rb2.AddExplosionForce(power, rb2.gameObject.transform.position, radius, 3.0f, ForceMode.Impulse);
                        }
                    }
                    target = target + new Vector3(0, -2.5f, 0);
                    rb.AddExplosionForce(power/2, rb.gameObject.transform.position, radius, 3.0f, ForceMode.Impulse);
                    Debug.Log("Hit " + hit.transform.gameObject.name);
                    audioSource.PlayOneShot(explode);
                }
            }
                
        }
    }
}
