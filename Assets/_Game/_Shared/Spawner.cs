

using System.Collections;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject[] whatToSpawn;
    


    private float spawnCooldown = 5f;
    private bool shouldSpawn = true;

    private void Spawn()
    {
        if(!shouldSpawn)
            return;


        int n = Random.Range(0, whatToSpawn.Length);
        Instantiate(whatToSpawn[n], spawnPoint);
        StartCoroutine(SpawnCooldown());
    }
    
    private IEnumerator SpawnCooldown()
    {
        shouldSpawn = false;
        yield return new WaitForSeconds(spawnCooldown);
        shouldSpawn = true;
    }

    private void Update()
    {
        Spawn();
    }
}
