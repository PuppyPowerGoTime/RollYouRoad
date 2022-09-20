using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metor : MonoBehaviour
{
    [SerializeField] private GameObject explotionEffect;
    [SerializeField] private GameObject warningCircle;

    GameObject warning;

    public void Start()
    {
        RaycastHit2D[] raycasthits = Physics2D.RaycastAll (transform.position, Vector2.down, 200);

        foreach(RaycastHit2D hit in raycasthits)
        {
            if (hit.collider.gameObject.tag == "Ground" || hit.collider.gameObject.tag == "Spikes")
            {
               warning = GameObject.Instantiate(warningCircle, new Vector3(hit.point.x, hit.point.y, 0), Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<Die>().KillPlayer();
            DestroyMetor();
        }

        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Spikes")
        {
            StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake(0.8f, 0.3f));
            DestroyMetor();
        }
    }

    public void DestroyMetor()
    {
        GameObject.FindObjectOfType<MetorSpawner>().gameObject.GetComponent<AudioSource>().Play();
        GameObject.Instantiate(explotionEffect, transform.position, Quaternion.identity);
        Destroy(warning);
        Destroy(gameObject);
    }
}
