using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMaxima = 5;
    public int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;
        LifeHUD.instance.AtualizarVida(vidaAtual);
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual < 0)
            vidaAtual = 0;

        LifeHUD.instance.AtualizarVida(vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
