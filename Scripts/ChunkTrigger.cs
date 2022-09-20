using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    [SerializeField] private GameObject chunk;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChunkManager chunkManager = GameObject.FindObjectOfType<ChunkManager>();
        chunkManager.SpawnChunk(chunk);

        if (!FindObjectOfType<MetorSpawner>().enabled)
        {
            FindObjectOfType<MetorSpawner>().enabled = true;
        }

        if (!FindObjectOfType<RocketSpawner>().enabled)
        {
            FindObjectOfType<RocketSpawner>().enabled = true;
        }

        Destroy(gameObject);
    }
}
