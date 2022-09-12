using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerShake : MonoBehaviour
{
    public IEnumerator CameraShakesEffect(float duraiton, float magnitude)
    {
        Vector3 orginalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duraiton)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, orginalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = orginalPos;
    }

    public void CameraShakesCall()
    {
        StartCoroutine(CameraShakesEffect(0.08f, 0.05f));
    }
}
