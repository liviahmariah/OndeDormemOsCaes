using UnityEngine;

public class PlayerBark : MonoBehaviour
{
    public GameObject barkWavePrefab;
    public Transform barkSpawnPoint;
    public float barkCooldown = 1f;

    bool canBark = true;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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

        // ANIMAÇÃO (visual)
        if (anim != null)
            anim.SetTrigger("isBarking");

        // GAMEPLAY (imediato)
        if (barkWavePrefab != null && barkSpawnPoint != null)
        {
            Instantiate(
                barkWavePrefab,
                barkSpawnPoint.position,
                barkSpawnPoint.rotation
            );
        }

        Invoke(nameof(ResetBark), barkCooldown);
    }

    void ResetBark()
    {
        canBark = true;
    }
}
