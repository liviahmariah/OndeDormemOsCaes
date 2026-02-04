using UnityEngine;

public class EnemyDetectionArea : MonoBehaviour
{
    public EnemyFollow enemyFollow;
    public EnemyAttack enemyAttack;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyFollow.enabled = true;
            enemyAttack.playerDetectado = true;
        }
    }
}
