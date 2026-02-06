using UnityEngine;

public class PlayerBark : MonoBehaviour
{
    public GameObject barkWavePrefab;
    public Transform barkSpawnPoint;
    public float barkCooldown = 1f;

    public AudioClip barkSound;
    public float barkVolume = 0.8f;

    bool canBark = true;
    Animator anim;
    AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && canBark)
        {
            Bark();
        }
    }

    void Bark()
    {
        canBark = false;

        // ANIMAÇÃO
        if (anim != null)
            anim.SetTrigger("isBarking");

        // 🔊 SOM DO LATIDO
        if (audioSource != null && barkSound != null)
        {
            audioSource.PlayOneShot(barkSound, barkVolume);
        }

        // GAMEPLAY
        if (barkWavePrefab != null && barkSpawnPoint != null)
        {
            GameObject bark = Instantiate(
                barkWavePrefab,
                barkSpawnPoint.position,
                Quaternion.identity
            );

            Vector3 scale = bark.transform.localScale;
            scale.x = Mathf.Sign(transform.localScale.x) * Mathf.Abs(scale.x);
            bark.transform.localScale = scale;
        }

        Invoke(nameof(ResetBark), barkCooldown);
    }

    void ResetBark()
    {
        canBark = true;
    }
}
