using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 2f;
    public float distanciaParar = 2.5f; // 👈 distância que ele PARA de andar

    [Header("Ataque")]
    public float distanciaAtaque = 1.5f;
    public int dano = 1;
    public float tempoEntreAtaques = 1f;

    public GameObject jumpscareUI;

    Transform player;
    PlayerHealth playerHealth;

    bool atacou = false;
    bool jumpscareJaMostrado = false;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
            playerHealth = playerObj.GetComponent<PlayerHealth>();
        }

        if (jumpscareUI != null)
            jumpscareUI.SetActive(false);
    }

    void Update()
    {
        if (player == null) return;

        float distancia = Vector2.Distance(transform.position, player.position);

        // 🟡 MOVIMENTO: só se aproxima até certa distância
        if (distancia > distanciaParar)
        {
            Aproximar();
        }

        // 🔴 ATAQUE
        if (distancia <= distanciaAtaque && !atacou)
        {
            Atacar();
        }
    }

    void Aproximar()
    {
        Vector2 direcao = (player.position - transform.position).normalized;
        transform.position += (Vector3)direcao * velocidade * Time.deltaTime;
    }

    void Atacar()
    {
        atacou = true;

        if (playerHealth != null)
        {
            playerHealth.TomarDano(dano);
        }

        if (!jumpscareJaMostrado && jumpscareUI != null)
        {
            jumpscareJaMostrado = true;
            jumpscareUI.SetActive(true);
            Invoke("FecharJumpscare", 1.0f);
        }
        else
        {
            Invoke("ResetarAtaque", tempoEntreAtaques);
        }
    }

    void FecharJumpscare()
    {
        if (jumpscareUI != null)
            jumpscareUI.SetActive(false);

        ResetarAtaque();
    }

    void ResetarAtaque()
    {
        atacou = false;
    }
}
