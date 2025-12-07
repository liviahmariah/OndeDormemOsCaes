using UnityEngine;

public class ConfigMenu : MonoBehaviour
{
    public GameObject painelConfiguracoes;
    public GameObject painelMenuPrincipal;

    public void AbrirConfiguracoes()
    {
        painelConfiguracoes.SetActive(true);
    }

    public void FecharConfiguracoes()
    {
        painelConfiguracoes.SetActive(false);
        painelMenuPrincipal.SetActive(true);
    }
}
