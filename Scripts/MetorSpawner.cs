using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetorSpawner : MonoBehaviour
{
    public float spawnRate = 5;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject metorPrefab;

    float timer;

    public void Update()
    {
        if(player != null)
        {
            timer += Time.deltaTime;

            if (timer > spawnRate)
            {
                timer = 0;
                Vector3 spawnPos = new Vector3(Random.Range(player.transform.position.x, player.position.x + 32), transform.position.y, 0);
                GameObject.Instantiate(metorPrefab, spawnPos, Quaternion.identity);
            }
        }
    }
}
