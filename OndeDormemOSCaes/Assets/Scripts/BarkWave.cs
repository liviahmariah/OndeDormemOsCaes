using UnityEngine;

public class BarkWave : MonoBehaviour
{
    public float radius = 4f;
    public float duration = 0.3f;

    void Start()
    {
        AfetarInimigos();
        Destroy(gameObject, duration);
    }

    void AfetarInimigos()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                EnemyAttack enemy = hit.GetComponent<EnemyAttack>();
                if (enemy != null)
                {
                    enemy.ReagirAoLatido();
                }
            }
        }
    }
}
