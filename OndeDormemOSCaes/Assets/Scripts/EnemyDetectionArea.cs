using UnityEngine;

public class EnemyDetectionArea : MonoBehaviour
{
    public EnemyFollow enemyFollow;
    public EnemyAttack enemyAttack;
    public AudioSource ghostAudio;
    public AudioClip ghostSound;

    private bool jaTocou = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyFollow.enabled = true;
            enemyAttack.playerDetectado = true;

            if (!jaTocou && ghostAudio != null && ghostSound != null)
            {
                ghostAudio.PlayOneShot(ghostSound);
                jaTocou = true;
            }
        }
    }
}
