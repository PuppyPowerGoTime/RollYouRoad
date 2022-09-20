using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenButtons : MonoBehaviour
{
    public void OnClickRetry()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(2);
    }

    public void OnClickMain()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(0);
    }
}
