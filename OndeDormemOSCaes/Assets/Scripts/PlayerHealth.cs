using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMaxima = 5;
    public int vidaAtual;

    SpriteRenderer sprite;
    Color corOriginal;

    void Start()
    {
        vidaAtual = vidaMaxima;
        LifeHUD.instance.AtualizarVida(vidaAtual);

        sprite = GetComponent<SpriteRenderer>();
        corOriginal = sprite.color;
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual < 0)
            vidaAtual = 0;

        LifeHUD.instance.AtualizarVida(vidaAtual);

        StartCoroutine(EfeitoDano());
        CameraShake.instance.Shake();

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    IEnumerator EfeitoDano()
    {
        sprite.color = new Color(1f, 0.6f, 0.6f); // vermelho mais claro
        yield return new WaitForSeconds(0.12f);
        sprite.color = corOriginal;
    }

    void Morrer()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
