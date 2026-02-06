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

        // ANIMAÇÃO
        if (anim != null)
            anim.SetTrigger("isBarking");

        if (barkWavePrefab != null && barkSpawnPoint != null)
        {
            GameObject bark = Instantiate(
                barkWavePrefab,
                barkSpawnPoint.position,
                Quaternion.identity
            );

            // 🔁 FAZ O LATIDO VIRAR JUNTO COM O PLAYER
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
