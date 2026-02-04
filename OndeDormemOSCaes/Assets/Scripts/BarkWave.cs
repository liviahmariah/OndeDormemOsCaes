using UnityEngine;

public class BarkWave : MonoBehaviour
{
    public float empurrao = 2.5f;
    public float duracao = 0.3f;

    void Start()
    {
        Destroy(gameObject, duracao);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Vector2 direcao = (other.transform.position - transform.position).normalized;
            other.transform.position += (Vector3)(direcao * empurrao);
        }
    }
}
