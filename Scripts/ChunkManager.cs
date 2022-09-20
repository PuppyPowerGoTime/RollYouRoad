using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> chunkList = new List<GameObject>();

    [SerializeField] private GameObject chunkPrefab;

    public int diceSpawnRate = 3;

    public void Update()
    {
        print(chunkList.Count);
    }

    public void SpawnChunk(GameObject chunckTriggered)
    {
        GameObject chunkSpawned = GameObject.Instantiate(chunkPrefab, new Vector3(chunckTriggered.transform.position.x + 122.48f, chunckTriggered.transform.position.y, 0), Quaternion.identity);
        chunkList.Add(chunkSpawned);

        Destroy(chunkList[0]);
        chunkList.Remove(chunkList[0]);
    }
}
