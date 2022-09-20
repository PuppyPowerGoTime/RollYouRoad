using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float mangintude)
    {
        Vector3 pos = transform.position;

        float elaped = 0.0f;

        while(elaped < duration)
        {
            float x = Random.Range(-1f, 1f) * mangintude;
            float y = Random.Range(-1f, 1f) * mangintude;

            transform.position = new Vector3(pos.x + x, pos.y + y, pos.z);

            elaped += Time.deltaTime;

            yield return null;

        }

        transform.position = pos;
    }
}
