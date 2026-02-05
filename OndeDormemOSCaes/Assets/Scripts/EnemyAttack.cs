using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [Header("Ataque")]
    public float distanciaAtaque = 1.8f;
    public int dano = 1;
    public float tempoEntreAtaques = 1.2f;

    [Header("Jumpscare")]
    public GameObject jumpscareUI;

    [HideInInspector] public bool playerDetectado = false;

    private Transform player;
    private PlayerHealth playerHealth;

    private bool podeAtacar = true;
    private bool jumpscareJaMostrado = false;

    // 🔴 PISCAR
    private SpriteRenderer spriteRenderer;
    private Color corOriginal;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
            playerHealth = playerObj.GetComponentInChildren<PlayerHealth>();
        }

        if (jumpscareUI != null)
            jumpscareUI.SetActive(false);

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            corOriginal = spriteRenderer.color;
    }

    void Update()
    {
        if (!playerDetectado) return;
        if (!podeAtacar) return;
        if (player == null) return;

        float distancia = Vector2.Distance(transform.position, player.position);

        if (distancia <= distanciaAtaque)
        {
            Atacar();
        }
    }

    void Atacar()
    {
        podeAtacar = false;

        Debug.Log("INIMIGO ATACOU");

        if (!jumpscareJaMostrado && jumpscareUI != null)
        {
            jumpscareJaMostrado = true;
            jumpscareUI.SetActive(true);
            Invoke(nameof(FecharJumpscare), 0.8f);
        }

        if (playerHealth != null)
        {
            playerHealth.TomarDano(dano);
        }

        Invoke(nameof(ResetarAtaque), tempoEntreAtaques);
    }

    // 🔴 CHAMADO PELO LATIDO
    public void ReagirAoLatido()
    {
        if (spriteRenderer != null)
        {
            StartCoroutine(Piscar());
        }
    }

    IEnumerator Piscar()
    {
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = corOriginal;
    }

    void FecharJumpscare()
    {
        if (jumpscareUI != null)
            jumpscareUI.SetActive(false);
    }

    void ResetarAtaque()
    {
        podeAtacar = true;
    }
}
