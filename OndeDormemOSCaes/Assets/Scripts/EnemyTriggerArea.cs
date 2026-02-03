using UnityEngine;

public class EnemyTriggerArea : MonoBehaviour
{
    public EnemyAttack enemy; // arrastar o inimigo aqui

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.playerDentroDaArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.playerDentroDaArea = false;
        }
    }
}
