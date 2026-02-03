using UnityEngine;

public class PlayerBark : MonoBehaviour
{
    public GameObject barkWavePrefab; // prefab da onda sonora
    public Transform barkSpawnPoint;   // ponto de saída da onda
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

        // animação do latido
        if (anim != null)
            anim.SetTrigger("Bark");

        // cria a onda sonora
        Instantiate(barkWavePrefab, barkSpawnPoint.position, Quaternion.identity);

        Invoke(nameof(ResetBark), barkCooldown);
    }

    void ResetBark()
    {
        canBark = true;
    }
}
