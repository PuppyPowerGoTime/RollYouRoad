using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Die : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject explotionPrefab;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private AudioSource explotionAudioSource;
    [SerializeField] private TextMeshProUGUI highScoreText;

    public void KillPlayer()
    {
        if (player != null)
        {
            if (PlayerPrefs.HasKey("Highscore"))
            {
                if (UIManager.distance > PlayerPrefs.GetInt("Highscore"))
                {
                    PlayerPrefs.SetInt("Highscore", UIManager.distance);
                }
            }
            else
            {
                PlayerPrefs.SetInt("Highscore", UIManager.distance);
            }

            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString() + "m";
            GameObject.Instantiate(explotionPrefab, player.transform.position, Quaternion.identity);
            Destroy(player);
            cam.gameObject.GetComponent<CameraMove>().shouldMove = false;
            deathCanvas.SetActive(true);
            scoreText.text = UIManager.distance + "m";
            distanceText.gameObject.SetActive(false);
            StartCoroutine(cam.gameObject.GetComponent<CameraShake>().Shake(0.8f, 0.3f));
            explotionAudioSource.Play();
        }
    }
}
