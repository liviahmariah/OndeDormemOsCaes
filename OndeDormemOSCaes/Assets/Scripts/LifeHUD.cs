using UnityEngine;

public class LifeHUD : MonoBehaviour
{
    public static LifeHUD instance;
    public GameObject[] coracoes;

    void Awake()
    {
        instance = this;
    }

    public void AtualizarVida(int vida)
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            coracoes[i].SetActive(i < vida);
        }
    }
}
