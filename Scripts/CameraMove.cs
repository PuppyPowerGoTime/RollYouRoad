using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public float camerMoveSpeed = 3;

    public bool shouldMove = true;
    [SerializeField] private Die die;

    void Update()
    {
        MoveCamera();

        if(player != null)
        {
            if (player.transform.position.x > transform.position.x + 20 || player.transform.position.x < transform.position.x - 20)
            {
                die.KillPlayer();
            }
        }
    }

    public void MoveCamera()
    {
        if (shouldMove) { transform.Translate(Vector3.right * camerMoveSpeed * Time.deltaTime); }
    }
}
