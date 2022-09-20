using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float rocketSpeed;
    [SerializeField] private float timeTillDestruction;
    [SerializeField] private GameObject explodeParticle;

    float timer;

    void Start()
    {
        timer += Time.deltaTime;

        if(timer > timeTillDestruction)
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        MoveRocket();
    }

    public void MoveRocket()
    {
        transform.Translate(Vector2.left * rocketSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Instantiate(explodeParticle, transform.position, Quaternion.identity);
            FindObjectOfType<MetorSpawner>().gameObject.GetComponent<AudioSource>().Play();
            FindObjectOfType<Die>().KillPlayer();
            Destroy(gameObject);
        }
    }
}
