using UnityEngine;

public class PlayerBark : MonoBehaviour
{
    public GameObject barkWavePrefab;
    public Transform barkSpawnPoint;
    public float barkCooldown = 1f;

    private bool canBark = true;
    private Animator anim;

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

        if (anim != null)
            anim.SetTrigger("Bark");

        Instantiate(barkWavePrefab, barkSpawnPoint.position, Quaternion.identity);

        Invoke(nameof(ResetBark), barkCooldown);
    }

    void ResetBark()
    {
        canBark = true;
    }
}
