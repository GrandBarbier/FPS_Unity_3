using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public Camera camera;
    
    public Transform firePoint;
    
    public GameObject boltPrefab;
    public GameObject crossbow;

    public float fireRate;
    public float power;

    private bool reloaded;
    
    

    void Start()
    {
        reloaded = true;
    }

    // Update is called once per frame
    void Update()
    { 
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            crossbow.transform.LookAt(hit.point);
            var dir = Quaternion.LookRotation(hit.point - firePoint.position);
            
            
            if (Input.GetButton("Fire1"))
            {
                if (reloaded)
                {
                    GameObject cloneBolt = Instantiate(boltPrefab, firePoint.position, Quaternion.identity);
                    cloneBolt.transform.rotation = crossbow.transform.rotation;
                    cloneBolt.GetComponent<Rigidbody>().AddForce(dir * Vector3.forward * power);
                    reloaded = false;
                    StartCoroutine(Reloading(fireRate));
                }
            }
        }
    }

    IEnumerator Reloading(float time)
    {
        yield return new WaitForSeconds(time);
        reloaded = true;
    }
}
