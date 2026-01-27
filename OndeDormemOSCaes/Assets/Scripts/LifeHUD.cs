using UnityEngine;
using UnityEngine.UI;

public class LifeHUD : MonoBehaviour
{
    public static LifeHUD instance;
    public Image[] coracoes;

    void Awake()
    {
        instance = this;
    }

    public void AtualizarVida(int vida)
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            coracoes[i].enabled = i < vida;
        }
    }
}
