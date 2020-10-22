using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void TakeDamage()
    {
        health = health - 1;

        
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
