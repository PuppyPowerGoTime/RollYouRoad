using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceManager : MonoBehaviour
{
    public TextMeshProUGUI rollText;

    [SerializeField] private CameraMove cameraMove;
    [SerializeField] private MetorSpawner metorSpawner;
    [SerializeField] private RocketSpawner rocketSpawner;
    [SerializeField] private ChunkManager chunkManager;

    [SerializeField] private float diceWaitTime = 5f;

    public void RollDice()
    {
        int n = Random.Range(1, 7);

        if (n == 1)
        {
            StartCoroutine(SpeedCamera());
        }
        else if (n == 2)
        {
            StartCoroutine(SlowCamera());
        }
        else if (n == 3)
        {
            StartCoroutine(FasterMetors());
        }
        else if (n == 4)
        {
            StartCoroutine(MoreMetors());
        }
        else if (n == 5)
        {
            StartCoroutine(MoreRocket());
        }
        else if (n == 6)
        {
            StartCoroutine(LessSpikes());
        }
    }

    public IEnumerator SpeedCamera()
    {
        float oldMoveSpeed = cameraMove.camerMoveSpeed;
        ShowRollText("Camera Has Been Speed Up!");
        cameraMove.camerMoveSpeed = 7;
        yield return new WaitForSeconds(diceWaitTime);
        cameraMove.camerMoveSpeed = oldMoveSpeed;
        HideRollText();
    }

    public IEnumerator SlowCamera()
    {
        float oldMoveSpeed = cameraMove.camerMoveSpeed;
        ShowRollText("Camera Has Been Slowed Down!");
        cameraMove.camerMoveSpeed = 4;
        yield return new WaitForSeconds(diceWaitTime);
        cameraMove.camerMoveSpeed = oldMoveSpeed;
        HideRollText();
    }

    public IEnumerator FasterMetors()
    {
        Vector3 oldMovePos = metorSpawner.gameObject.transform.position;
        ShowRollText("Metors have Been Speed Up!");
        metorSpawner.gameObject.transform.position = new Vector3(metorSpawner.gameObject.transform.position.x, 41, 0);
        yield return new WaitForSeconds(diceWaitTime);
        metorSpawner.gameObject.transform.position = oldMovePos;
        HideRollText();
    }

    public IEnumerator MoreMetors()
    {
        float oldSpawnRate = metorSpawner.spawnRate;
        ShowRollText("There are now More Metors!");
        metorSpawner.spawnRate = 1.75f;
        yield return new WaitForSeconds(diceWaitTime);
        metorSpawner.spawnRate = oldSpawnRate;
        HideRollText();
    }

    public IEnumerator MoreRocket()
    {
        float x = rocketSpawner.x;
        float y = rocketSpawner.y;

        ShowRollText("There are now More Rockets!");

        rocketSpawner.x = 1;
        rocketSpawner.y = 4;

        yield return new WaitForSeconds(diceWaitTime);

        rocketSpawner.x = x;
        rocketSpawner.y = y;

        HideRollText();
    }

    public IEnumerator LessSpikes()
    {
        ShowRollText("There are now Less Spikes!");

        int oldSpawnRate = chunkManager.diceSpawnRate;
        chunkManager.diceSpawnRate = 4;
        yield return new WaitForSeconds(diceWaitTime);
        chunkManager.diceSpawnRate = oldSpawnRate;
        HideRollText();
    }

    public void ShowRollText(string text)
    {
        rollText.gameObject.SetActive(true);
        rollText.text = text;
    }

    public void HideRollText()
    {
        rollText.gameObject.SetActive(true);
    }

}
