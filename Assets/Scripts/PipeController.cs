using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefabs;
    
    [SerializeField] private float speedPipe = 2f;
    [SerializeField] private float spawnX = 10f;
    [SerializeField] private float maxSpawnY = -3.5f;
    [SerializeField] private float minSpawnY = -7.5f;
    [SerializeField] private float destoryPipe = -12f;
    [SerializeField] private float spawnTime = 2.25f;
    private bool isRunning;
    private Coroutine spawnCoroutine;


    private readonly List<GameObject> pipes = new List<GameObject>();

    public void spawnPipe()
    {
        float randomY = Random.Range(minSpawnY, maxSpawnY);
        Vector3 spawnPos = new Vector3(spawnX, randomY, 0);

        GameObject newPipe = Instantiate(pipePrefabs, spawnPos, Quaternion.identity);
        pipes.Add(newPipe);
    }

    // Sdung cau truc yield return IEnumerator de tao Coroutine
    private IEnumerator SpawnPipeRoutine()
    {
        while (true)
        {
            spawnPipe();
            yield return new WaitForSeconds(spawnTime);
        }
        
    }

    public void startPipes()
    {
        isRunning = true;
        if(spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnPipeRoutine());
        }
    }

    public void stopPipes()
    {
        isRunning = false;
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    public void movePipes()
    {
        for (int i = pipes.Count - 1; i >= 0 ; i--)
        {
            if (pipes[i] == null)
            {
                pipes.RemoveAt(i);
                continue;
            }

            pipes[i].transform.position += Vector3.left * speedPipe * Time.fixedDeltaTime;

            if (pipes[i].transform.position.x <= destoryPipe)
            {
                Destroy(pipes[i]);
                pipes.RemoveAt(i);
            }
        }
    }

    public void FixedUpdate()
    {
        if (!isRunning)
        {
            return;
        }
        movePipes();
    }

}
