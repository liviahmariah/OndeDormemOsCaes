using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    Vector3 posOriginal;

    public float intensidade = 0.15f;
    public float duracao = 0.15f;

    void Awake()
    {
        instance = this;
        posOriginal = transform.localPosition;
    }

    public void Shake()
    {
        StopAllCoroutines();
        StartCoroutine(ShakeRotina());
    }

    IEnumerator ShakeRotina()
    {
        float tempo = 0;

        while (tempo < duracao)
        {
            float x = Random.Range(-intensidade, intensidade);
            float y = Random.Range(-intensidade, intensidade);

            transform.localPosition = posOriginal + new Vector3(x, y, 0);

            tempo += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = posOriginal;
    }
}
