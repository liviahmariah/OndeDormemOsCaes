using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyAttack : MonoBehaviour
{
    [Header("Ataque")]
    public float distanciaAtaque = 1.8f;
    public int dano = 1;
    public float tempoEntreAtaques = 1.2f;

    [Header("Jumpscare")]
    public GameObject jumpscareUI;
    public AudioClip jumpscareSound;
    public float jumpscareVolume = 1f;

    [HideInInspector] public bool playerDetectado = false;

    private Transform player;
    private PlayerHealth playerHealth;

    private bool podeAtacar = true;
    private bool jumpscareJaMostrado = false;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f; // áudio 2D
        audioSource.ignoreListenerPause = true;
    }

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

        // 👻 JUMPSCARE (SÓ UMA VEZ NO JOGO)
        if (!jumpscareJaMostrado && jumpscareUI != null)
        {
            jumpscareJaMostrado = true;

            jumpscareUI.SetActive(true);

            if (jumpscareSound != null)
            {
                audioSource.Stop();
                audioSource.clip = jumpscareSound;
                audioSource.volume = jumpscareVolume;
                audioSource.Play();

                // fecha quando o áudio acabar
                Invoke(nameof(FecharJumpscare), jumpscareSound.length);
            }
            else
            {
                Invoke(nameof(FecharJumpscare), 1f);
            }
        }

        // ⚠️ DANO NORMAL (continua funcionando depois)
        if (playerHealth != null)
        {
            playerHealth.TomarDano(dano);
        }

        Invoke(nameof(ResetarAtaque), tempoEntreAtaques);
    }

    void FecharJumpscare()
    {
        if (jumpscareUI != null)
            jumpscareUI.SetActive(false);

        // NÃO reseta jumpscareJaMostrado
        // ele fica true pra sempre
    }

    void ResetarAtaque()
    {
        podeAtacar = true;
    }
}
