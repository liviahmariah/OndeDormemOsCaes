using UnityEngine;

public class LifeHUD : MonoBehaviour
{
    public GameObject[] coracoes;

    public void AtualizarVida(int vidaAtual)
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            coracoes[i].SetActive(i < vidaAtual);
        }
    }
}
