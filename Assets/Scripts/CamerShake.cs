using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerShake : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;

    public IEnumerator CameraShakesEffect(float duraiton, float magnitude)
    {

        Vector3 orginalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duraiton)
        {
            float x = Random.Range(-0.5f, 0.5f) * magnitude;
            float y = Random.Range(-0.5f, 0.5f) * magnitude;
            float strength = curve.Evaluate(elapsed / duraiton);
            transform.localPosition = new Vector3(x, y, orginalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = orginalPos;
    }

    public void CameraShakesCall()
    {
        StartCoroutine(CameraShakesEffect(0.02f , 0.1f));
    }
  
}
