using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMaxima = 5;
    public int vidaAtual;

    public LifeHUD lifeHUD;

    void Start()
    {
        vidaAtual = vidaMaxima;
        lifeHUD.AtualizarVida(vidaAtual);
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual < 0)
            vidaAtual = 0;

        lifeHUD.AtualizarVida(vidaAtual);

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                TomarDano(1);
            }
        }

    }
}
