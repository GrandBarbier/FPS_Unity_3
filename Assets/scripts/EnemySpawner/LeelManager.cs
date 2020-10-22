using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting; 

public class LeelManager : MonoBehaviour
{
    public Wave[] allWave;
    public int maxWaveCount;
    public Transform spawnPosition;
    
    [System.Serializable] 
    public class Wave
    {
        public EnemySpawner[] spawners;
    }

    public void Start()
    {
        StartCoroutine(SpawnEnemyWave(maxWaveCount));
    }
    
    public IEnumerator SpawnEnemyWave(int maxWave)
    {
        if (maxWave > allWave.Length) maxWave = allWave.Length;
        
        // Loop in all needed wave
        for (int i = 0; i < maxWave; i++)
        {
            List<GameObject> enemies = new List<GameObject>();
            
            // Spawn 1 wave
            foreach (var spawner in allWave[i].spawners)
            {
                enemies.Add(spawner.Spawn());
            }
            
            // Check all ennemies are dead
            while (enemies.Count > 0)
            {
                for (int y = 0; y < enemies.Count; y++)
                {
                    if (!enemies[y])
                    {
                        enemies.RemoveAt(y);
                        y--;
                    }
                }
                
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
        yield return null;
    }
}
