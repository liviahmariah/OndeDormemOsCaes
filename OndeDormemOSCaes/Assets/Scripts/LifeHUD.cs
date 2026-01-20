using UnityEngine;

public class LifeHUD : MonoBehaviour
{
    public GameObject[] coracoes;

    public void AtualizarVida(int vidaAtual)
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            if (i < vidaAtual)
                coracoes[i].SetActive(true);
            else
                coracoes[i].SetActive(false);
        }
    }
}
