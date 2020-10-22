using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;

    public float health = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
