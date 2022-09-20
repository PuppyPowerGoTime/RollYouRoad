using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Die die;

    public void Start()
    {
        die = FindObjectOfType<Die>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            die.KillPlayer();
        }
    }
}
