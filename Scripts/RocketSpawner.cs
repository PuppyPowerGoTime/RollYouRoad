using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    float spawnRate;

    public float x = 2;
    public float y = 6;

    float timer;

    public void Start()
    {
        spawnRate = Random.Range(x, y);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > spawnRate)
        {
            timer = 0;
            spawnRate = Random.Range(x, y);

            GameObject.Instantiate(rocketPrefab, new Vector3(transform.position.x, Random.Range(1, 3.5f), 0), Quaternion.identity);
        }
    }
}
