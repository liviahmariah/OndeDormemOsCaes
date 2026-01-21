using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMaxima = 3;
    public int vidaAtual;

    public LifeHUD hud;

    void Start()
    {
        vidaAtual = vidaMaxima;
        hud.AtualizarVida(vidaAtual);
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;
        if (vidaAtual < 0) vidaAtual = 0;

        hud.AtualizarVida(vidaAtual);

        if (vidaAtual == 0)
        {
            Debug.Log("Game Over");
        }
    }
}
