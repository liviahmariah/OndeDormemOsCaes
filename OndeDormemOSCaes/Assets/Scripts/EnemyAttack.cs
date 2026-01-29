using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float distanciaAtaque = 1.5f;
    public int dano = 1;
    public GameObject jumpscareUI;

    Transform player;
    PlayerHealth playerHealth;

    bool atacou = false;
    bool jumpscareJaMostrado = false; // ✅ CONTROLA SE JÁ MOSTROU

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
        if (player == null || atacou) return;

        float distancia = Vector2.Distance(transform.position, player.position);

        if (distancia <= distanciaAtaque)
        {
            Atacar();
        }
    }

    void Atacar()
    {
        atacou = true;

        Debug.Log("Inimigo atacou!");

        if (playerHealth != null)
        {
            playerHealth.TomarDano(dano);
        }

        // ✅ MOSTRA JUMPSCARE SÓ NA PRIMEIRA VEZ
        if (!jumpscareJaMostrado && jumpscareUI != null)
        {
            jumpscareJaMostrado = true;
            jumpscareUI.SetActive(true);
            Invoke("FecharJumpscare", 1.0f);
        }
        else
        {
            Invoke("ResetarAtaque", 1.0f);
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
