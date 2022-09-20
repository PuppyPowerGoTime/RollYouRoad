using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private List<GameObject> startingChunks = new List<GameObject>();
    [SerializeField] private List<Transform> spikePoints = new List<Transform>();

    [SerializeField] private GameObject spikePrefab;

    [SerializeField] private Transform diceSpawnPoint;
    [SerializeField] private GameObject dicePrefab;

    private ChunkManager chunkManager;

    public void Start()
    {
        chunkManager = FindObjectOfType<ChunkManager>();

        SpawnSpikes();
        SpawnDice();
    }

    public void SpawnSpikes()
    {
        if (!startingChunks.Contains(gameObject))
        {
            foreach(Transform spikePoint in spikePoints)
            {
                int n = Random.Range(1, chunkManager.diceSpawnRate);

                if(n == 1)
                {
                    GameObject spike = GameObject.Instantiate(spikePrefab, spikePoint.position, Quaternion.identity);
                    spike.transform.parent = transform;
                }
            }
        }
    }

    public void SpawnDice()
    {
        int n = Random.Range(1, 3);

        if(n == 1)
        {
            GameObject.Instantiate(dicePrefab, diceSpawnPoint.transform.position, Quaternion.identity);
        }
    }
}
