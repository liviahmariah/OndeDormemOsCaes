using UnityEngine;

public class BarkWave : MonoBehaviour
{
    public float expandSpeed = 5f;
    public float maxSize = 3f;
    public float pushForce = 5f;

    void Update()
    {
        transform.localScale += Vector3.one * expandSpeed * Time.deltaTime;

        if (transform.localScale.x >= maxSize)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ghost"))
        {
            Vector2 dir = other.transform.position - transform.position;
            dir.Normalize();

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(dir * pushForce, ForceMode2D.Impulse);
            }
        }
    }
}
