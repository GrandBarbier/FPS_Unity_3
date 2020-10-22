using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    public GameObject Spawn()
    {
        GameObject e = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        return e;
    }
}
