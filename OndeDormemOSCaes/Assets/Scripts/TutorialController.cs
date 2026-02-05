using UnityEngine;
using TMPro; // se usar TextMeshPro

public class TutorialController : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;

    private int etapa = 0;

    private bool movimentoFeito = false;
    private bool puloFeito = false;
    private bool latidoFeito = false;

    void Start()
    {
        MostrarComando();
    }

    void Update()
    {
        // 🟢 ETAPA 0 — MOVIMENTO
        if (etapa == 0)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                movimentoFeito = true;
            }

            if (movimentoFeito)
            {
                etapa++;
                MostrarComando();
            }
        }

        // 🟡 ETAPA 1 — PULO
        else if (etapa == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                puloFeito = true;
            }

            if (puloFeito)
            {
                etapa++;
                MostrarComando();
            }
        }

        // 🔵 ETAPA 2 — LATIDO
        else if (etapa == 2)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                latidoFeito = true;
            }

            if (latidoFeito)
            {
                FinalizarTutorial();
            }
        }
    }

    void MostrarComando()
    {
        if (etapa == 0)
        {
            tutorialText.text = "Use WASD ou as SETAS para se mover";
        }
        else if (etapa == 1)
        {
            tutorialText.text = "Pressione ESPAÇO para pular";
        }
        else if (etapa == 2)
        {
            tutorialText.text = "Pressione Z para latir";
        }
    }

    void FinalizarTutorial()
    {
        tutorialText.text = "";
        gameObject.SetActive(false);
    }
}
