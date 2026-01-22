using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMaxima = 3;
    public int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual < 0)
            vidaAtual = 0;

        Debug.Log("Vida: " + vidaAtual);

        if (vidaAtual == 0)
        {
            Debug.Log("Player morreu");
        }
    }
}
