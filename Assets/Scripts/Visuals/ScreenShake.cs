using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static bool screenShake = true;
    public IEnumerator Shake(float duration, float magnitude)
    {
        if (screenShake)
        {
            Vector3 originalPos = transform.localPosition;
            float elapsed = 0.0f;
            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, originalPos.z);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = originalPos;
        }
    }
}
