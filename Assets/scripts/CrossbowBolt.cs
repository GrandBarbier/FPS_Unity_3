using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowBolt : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 eulerAngleVelocity;
    
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        eulerAngleVelocity = new Vector3(0, 100000, 0);
    }

    void Update()
    {
        Destroy(gameObject, 30f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Pierceable")
        {
            gameObject.transform.parent = other.transform;
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            rb.velocity *= 0.5f ;
            foreach (var contact in other.contacts)
            {
                
            }
        }
    }
}
