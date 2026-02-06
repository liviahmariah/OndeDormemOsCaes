using UnityEngine;

public class EnemyVisionMusic : MonoBehaviour
{
    [Header("Referências")]
    public Transform player;
    public PlayerMovement playerMovement; // pra saber a direção
    public AudioSource musicSource;
    public AudioClip adaptiveMusic;

    [Header("Visão")]
    public float visionDistance = 6f;
    [Range(0f, 1f)] public float visionDot = 0.6f;

    [Header("Áudio")]
    public float musicVolume = 1f;

    private bool musicaJaTrocou = false;

    void Update()
    {
        if (musicaJaTrocou) return;
        if (player == null || musicSource == null || adaptiveMusic == null) return;

        Vector2 dirToEnemy = (transform.position - player.position).normalized;

        // direção que o player está olhando
        Vector2 playerLookDir = playerMovement.LastMoveDirection;

        float dot = Vector2.Dot(playerLookDir, dirToEnemy);
        float distance = Vector2.Distance(player.position, transform.position);

        // 👁️ inimigo entrou no campo de visão
        if (dot > visionDot && distance <= visionDistance)
        {
            TrocarMusica();
        }
    }

    void TrocarMusica()
    {
        musicaJaTrocou = true;

        musicSource.Stop();
        musicSource.clip = adaptiveMusic;
        musicSource.volume = musicVolume;
        musicSource.loop = true;
        musicSource.Play();
    }
}
